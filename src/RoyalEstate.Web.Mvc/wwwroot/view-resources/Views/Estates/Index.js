$(() => {
    let _estateService = abp.services.app.estate;   
    let _cityService = abp.services.app.city;
    let _districtService = abp.services.app.district;
    const pageSize = 30;
    let startIndex = 1;
    let endIndex = 30;

    let filtersObject = {
        maxResultCount: pageSize,
        skipCount: 0,
        sorting: "OrderDate DESC",
        isActive: true
    };

    let canLoadUp = false;
    let canLoadDown = true;
    let lastScrollTop = 0;
        
    let maxLoadSize = parseInt($("#loadSizes div").first(x => x.css("display") === "block").attr("data-loadSize"));        
    
    const dirUp = "up";
    const dirDown = "down";

    let wh = $(window).height();

    let firstDiv = null;

    let loadEstates = (filters, dir) => {
        if (dir==dirUp && startIndex==1) {
            return;
        }
        _estateService.getAll(filters).done(function (result) {
            let length = result.items.length;
            if (length == 0) {
                canLoadDown = false;
                return;
            }            
            if (dir == dirDown) {                
                result.items.forEach(e => {
                    $("#estatesSection").append(renderEstate(e));                    
                });
                
                if ($("#estatesSection>div").length > pageSize) {        
                    
                    let pTop = parseInt($("#estatesSection").css("padding-top"))
                        + ($("#estatesSection>div")[length - 1].offsetTop
                            - $("#estatesSection>div")[0].offsetTop)
                        + $("#estatesSection>div")[length - 1].offsetHeight;
                        
                    
                    $("#estatesSection").css("padding-top", `${pTop}px`);
                    for (var i = 0; i < length; i++) {
                        $("#estatesSection>div:first-child").remove();
                    }                            
                    startIndex += length;
                    endIndex += length;                    
                } else {
                    endIndex = length;
                }                
                firstDiv = $("#estatesSection>div:first-child");
            }
            else if (dir == dirUp) {                     
                let pTop = parseInt($("#estatesSection").css("padding-top"))
                    - ($("#estatesSection>div")[length - 1].offsetTop
                        - $("#estatesSection>div")[0].offsetTop)   
                    - $("#estatesSection>div")[length - 1].offsetHeight;
                $("#estatesSection").css("padding-top", pTop + "px");

                result.items.reverse().forEach(e => {
                    $("#estatesSection").prepend(renderEstate(e));                    
                });
                firstDiv = $("#estatesSection>div:first-child");      
                                                
                
                if ($("#estatesSection>div").length > pageSize) {                                        
                    for (var i = 0; i < length; i++) {
                        $("#estatesSection>div:last-child").remove();                        
                    }
                    startIndex -= length;
                    endIndex -= length;                                       
                }     

                
            }  
            canLoadUp = true;
            canLoadDown = true;
        });
    };

    _cityService.getAll({}).done(function (result) {
        result.items.forEach(c => {
            $("select[name='cityId']").append(`<option value='${c.id}'>${c.name}</option>`)
        });
    });
    $("select[name='cityId']").change(function() {
        let districtSelect = $("select[name='districtId']");
        $(districtSelect).empty();
        $(districtSelect).trigger('change');
        let cityId = $(this).val();
        if (cityId == null || cityId == "")
            return;
        $(districtSelect).append(`<option value=''>همه</option>`);
        _districtService.getAll({ cityId: cityId }).done(function(result) {
            result.items.forEach(d => {
                $(districtSelect).append(`<option value='${d.id}'>${d.name}</option>`);
            });
        });
    });

    loadEstates(filtersObject, dirDown);   

    $(window).scroll(function () {
        let st = $(window).scrollTop();
        let dh = $(document).height();
        if (st > lastScrollTop && st + wh > dh * 0.9 && canLoadDown) {
            //scroll down
            canLoadDown = false;
            lazyLoadDown();        
        } else if (st < lastScrollTop && st < $(firstDiv).offset().top && canLoadUp) {                            
            //scroll up
            canLoadUp = false;  
            lazyLoadUp();
        }
        lastScrollTop = st <= 0 ? 0 : st;
    });

    window.addEventListener("resize", function () {
        maxLoadSize = parseInt($("#loadSizes div").first(x => x.css("display") === "block").attr("data-loadSize"));
        wh = $(window).height();
    })

    let renderEstate = (estate) => `<div class="col-12 col-sm-6 col-xl-3 mb-3">
                                <a href="/Estates/Single/?id=${estate.id}" target="_blank">
                                    <div class="card estateCard m-0">
                                        <div class="row no-gutters h-100">
                                            <div class="col-7 h-100">
                                                <div class="h-100 d-flex flex-column justify-content-between p-0">
                                                    <div class="px-2 py-1 overflow-hidden text-bold">
                                                        ${estate.title}
                                                    </div>

                                                    <div class="px-2 py-1">
                                                         کد: ${estate.filingCode ? estate.filingCode : ""}
                                                        <br/><span class="badge text-right" style="font-size: 0.9rem; font-weight: bold; background-color:${
        estate.estateTypeColor} ">${estate.rent
        ? 'رهن: ' + thousands_separators(estate.deposit) + ' میلیون تومان<br/>' + 'اجاره: ' + thousands_separators(estate.rent)
        : 'قیمت: ' + thousands_separators(estate.price * estate.area) + ' میلیون تومان'}</span>
                                                        
                                                        <br/>
                                                        تاریخ: ${new persianDate(new Date(estate.creationTime)).format(
            "DD MMMM YYYY")}
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-5 h-100" style="background-image:url('${getThumbnailPath(
            estate.imagePaths[0])}'); background-size:cover"></div>
                                        </div>
                                    </div>
                                </a>
                            </div>`;

    function lazyLoadUp() {
        if (startIndex==1) {
            return;
        }
        filtersObject.maxResultCount = startIndex > maxLoadSize ? maxLoadSize : (startIndex - 1);
        filtersObject.sorting = "OrderDate DESC";
        filtersObject.skipCount = startIndex <= maxLoadSize ? 0 : (startIndex - maxLoadSize - 1);
        loadEstates(filtersObject, dirUp);
    }

    function lazyLoadDown() {                  
        filtersObject.maxResultCount = maxLoadSize;
        filtersObject.sorting = "OrderDate DESC";
        filtersObject.skipCount = endIndex;
        loadEstates(filtersObject, dirDown);
    }

    function getThumbnailPath(p) {
        if (p) {
            let i = p.lastIndexOf('/') + 1;
            let dot = p.lastIndexOf('.');
            let str = p.substring(0, i) + "thumbnail" + p.substring(dot);
            return str;
        }
        return '';
    }

    $("#frmSearch").submit(function () {        
        $("#IsBusy").modal("show");        
        let term = $("#frmSearch input[name='term']").val();
        
        resetLazyLoad();
        filtersObject.maxResultCount = pageSize;
        filtersObject.sorting = "OrderDate DESC";
        filtersObject.skipCount = 0;
        filtersObject = { ...filtersObject, term }       
        if (term != "") {
            $(".tag-search span").html(term).parent().removeClass("d-none");
        } else {
            $(".tag-search span").html('').parent().addClass("d-none");
        }        
        loadEstates(filtersObject, dirDown);
        $("#IsBusy").modal("hide");
        return false;
    })

    $("#frmFilters").submit(function(e) {
        $("#IsBusy").modal('show');
        let s = $(this).serializeArray().reduce((obj, { name, value }) => {
                obj[name] = value;
                return obj;
            },
            {});
        
        resetLazyLoad();
        filtersObject.maxResultCount = pageSize;
        filtersObject.sorting = "OrderDate DESC";
        filtersObject.skipCount = 0;
        filtersObject = { ...filtersObject, ...s }
        filtersObject.elevator = $(".filter-elevator input").is(":checked");
        filtersObject.parking = $(".filter-parking input").is(":checked");
        filtersObject.isActive = $("#onlyActiveEstates").is(":checked");
        loadEstates(filtersObject, dirDown);
        checkFilterTags(filtersObject);
        $(this).parent().collapse("hide");
        $("#IsBusy").modal('hide');
        return false;
    });

    $("#btnResetFilters").click(function() {
        $("#frmFilters").trigger('reset');
        $("#frmFilters .form-group[class*='filter-']").addClass("d-none");
        $("#frmFilters").submit();
    });

    function checkFilterTags(filters) {
        $(".tag-badge").each((i, t) => {
            $(t).addClass("d-none");
            let classNames = t.className.split(/\s+/);
            let propNames = classNames.find(c => c.startsWith("filter-")).split(/-/);
            propNames.shift();
            let found = false;
            if (propNames.length > 1) {
                for (let p in propNames) {
                    if (filters[propNames[p]]) {
                        found = true;
                        break;
                    }
                }
            } else if (filters[propNames[0]])
                found = true;
            if (!found) {
                return;
            }
            if ($(t).hasClass("hasData")) {
                $(t).find("[class^='filterData-']").each((j, d) => {
                    let prop = d.className.split(/-/)[1];
                    let v = filters[prop];
                    $(d).text(v==""||v==null?'هرچقدر':v);
                });
            } else if ($(t).hasClass("fromSelect")) {
                $(t).find("[class^='filterData-']").text($($(t).attr("data-target") + " option:selected").html());
            }
            $(t).removeClass("d-none");
        });
        updateQuickFiltersColors();
    }

    $(".tag-badge .fa-times").click(function () {
        $("#IsBusy").modal('show');
        let tag = $(this).parent()[0];
        let classNames = tag.className.split(/\s+/);
        let propNames = classNames.find(c => c.startsWith("filter-")).split(/-/);
        propNames.shift();
        let isCheckBox = !($(tag).hasClass("hasData") || $(tag).hasClass("fromSelect"));
        if (isCheckBox) {
            for (p in propNames) {
                filtersObject[propNames[p]] = false;
                $(`#frmFilters input[name='${propNames[p]}']`).prop('checked', false);
            }
        } else {
            for (p in propNames) {
                filtersObject[propNames[p]] = '';
                if ($(tag).hasClass('fromSelect'))
                    $($(tag).attr("data-target")).val('').change();
                else
                    $(`#frmFilters input[name='${propNames[p]}']`).val('').change();
            }
        }
        
        $(tag).addClass("d-none");
        
        resetLazyLoad();
        filtersObject.maxResultCount = pageSize;
        filtersObject.skipCount = 0;
        filtersObject.elevator = $(".filter-elevator input").is(":checked");
        filtersObject.parking = $(".filter-parking input").is(":checked");
        filtersObject.isActive = $("#onlyActiveEstates").is(":checked");
        loadEstates(filtersObject, dirDown);

        updateQuickFiltersColors();

        $("#filtersBox").collapse('hide');
        $("#IsBusy").modal('hide');
    })

    $(".tag-search .fa-times").click(function () {
        $("#IsBusy").modal("show");
        $(this).before().html('').parent().addClass("d-none");
        $("#frmSearch input").val('').change();
        resetLazyLoad();
        filtersObject.term = null;
        loadEstates(filtersObject, dirDown);
        $("#filtersBox").collapse('hide');
        $("#IsBusy").modal('hide');
    })

    function resetLazyLoad() {        
        $("#estatesSection").empty();
        $("#estatesSection")[0].style.paddingTop = 0;
        startIndex = 1;
        endIndex = 30;
        canLoadUp = false;
        canLoadDown = true;
        lastScrollTop = 0;        
    }

    $(".quickFilter").click(function () {
        let tagId = $(this).attr("data-id");
        $("#frmFilters").trigger("reset");
        $("#selectEstateType").val(tagId).change();
        $("#frmFilters").submit();
    });

    function updateQuickFiltersColors() {
        let selectedCat = $("#selectEstateType").val();
        $(".quickFilter").unbind('mouseenter mouseleave');
        $(`.quickFilter[data-id!='${selectedCat}']`).css("background-color", "rgba(150, 150, 150, 0.5)").hover(
            function () {
                $(this).css("background-color", "rgba(250, 250, 50, 0.5)")
            },
            function () {
                $(this).css("background-color", "rgba(150, 150, 150, 0.5)")
            }
        );
        $(`.quickFilter[data-id='${selectedCat}']`).css("background-color", "rgba(250, 250, 50, 0.5)");
    }
});

