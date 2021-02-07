$(() => {
    let _estateService = abp.services.app.estate;
    _estateService.getAll({}).done(function(result) {
        console.log(result);
        result.items.forEach(r => {
            $("#estatesSection").append(`<div class="col-12 col-sm-6 col-md-4 col-lg-3 ">
                                <div class="card">
                                    <div class="card-header">
                                        <p>${r.title}</p>
                                    </div>
                                    <div class="card-body" style="height:7rem">
                                        <img class="estateCover" src="/${r.imagePaths[0]}"/>
                                    </div>
                                    <div class="card-footer">
                                        قیمت<p>${r.price}</p>
                                    </div>
                                </div>
                            </div>`)
        })
    });
})