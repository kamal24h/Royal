$(() => {
    let _estateService = abp.services.app.estate;   
    const pageSize = 30;
    let startIndex = 1;
    let endIndex = 30;

    let filtersObject = {
        maxResultCount: pageSize,
        skipCount: 0
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
        let maxLoadSize = parseInt($("#loadSizes div").first(x => x.css("display") === "block").attr("data-loadSize"));
        wh = $(window).height();
    })

    let renderEstate = (estate) => `<div class="col-12 col-sm-6 col-xl-4 mb-4">
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
                                                        <br/>
                                                        قیمت: ${estate.price ? estate.price : ""} میلیون تومان
                                                        <br/>
                                                        رهن: ${estate.deposit ? estate.deposit : ""} - اجاره: ${estate.rent ? estate.rent : ""}
                                                        <br/>
                                                        تاریخ: ${new persianDate(new Date(estate.creationTime)).format("DD MMMM YYYY")}
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-5 h-100" style="background-image:url('${estate.imagePaths[0] || ''}'); background-size:cover"></div>
                                        </div>
                                    </div>
                                </a>
                            </div>`;

    function lazyLoadUp() {
        if (startIndex==1) {
            return;
        }
        filtersObject.maxResultCount = startIndex > maxLoadSize ? maxLoadSize : (startIndex - 1);    
        filtersObject.skipCount = startIndex <= maxLoadSize ? 0 : (startIndex - maxLoadSize - 1);
        loadEstates(filtersObject, dirUp);
    }

    function lazyLoadDown() {                  
        filtersObject.maxResultCount = maxLoadSize;
        filtersObject.skipCount = endIndex;
        loadEstates(filtersObject, dirDown);
    }

    $("#frmSearch").submit(function () {        
        let s = $(this).serializeArray().reduce((obj, { name, value }) => {
            obj[name] = value;
            return obj;
        }, {});
        $("#estatesSection").empty();
        $("#estatesSection")[0].style.paddingTop = 0;
        startIndex = 1;
        endIndex = 30;
        canLoadUp = false;
        canLoadDown = true;
        lastScrollTop = 0;
        filtersObject.maxResultCount = pageSize;
        filtersObject.skipCount = 0;
        filtersObject = {...filtersObject, ...s }        
        loadEstates(filtersObject, dirDown);
        return false;
    })

    $("#frmFilters").submit(function (e) {
        $("#IsBusy").modal('show');
        let s = $(this).serializeArray().reduce((obj, { name, value }) => {
            obj[name] = value;
            return obj;
        }, {});
        $("#estatesSection").empty();
        $("#estatesSection")[0].style.paddingTop = 0;
        startIndex = 1;
        endIndex = 30;
        canLoadUp = false;
        canLoadDown = true;
        lastScrollTop = 0;
        filtersObject.maxResultCount = pageSize;
        filtersObject.skipCount = 0;
        filtersObject = { ...filtersObject, ...s }
        loadEstates(filtersObject, dirDown);
        $(this).parent().collapse("hide");   
        $("#IsBusy").modal('hide');
        return false;
    })

    $("#btnResetFilters").click(function () {
        $("#frmFilters").trigger('reset');
        $("#frmFilters").submit();
    })
});

