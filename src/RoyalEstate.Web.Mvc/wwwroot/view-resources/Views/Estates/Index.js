$(() => {
    let _estateService = abp.services.app.estate;
    _estateService.getAll({}).done(function(result) {
        console.log(result);
        result.items.forEach(e => {
            $("#estatesSection").append(renderEstate(e));
        });
    });
});

let renderEstate = (estate) => `<div class="col-12 col-sm-6 col-xl-4">
                                <a href="/Estates/Single/?id=${estate.id}">
                                    <div class="card estateCard m-0">
                                        <div class="row no-gutters h-100">
                                            <div class="col-7 h-100">
                                                <div class="h-100 d-flex flex-column justify-content-between p-0">
                                                    <div class="px-2 py-1 overflow-hidden text-bold">
                                                        ${estate.title}
                                                    </div>
                                                    <div class="px-2 py-1">
                                                        قیمت: ${estate.price}
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