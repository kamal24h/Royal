$(() => {    
    let _customerService = abp.services.app.customer,
        _cityService = abp.services.app.city,
        l = abp.localization.getSource('RoyalEstate'),
        _$form = $("#frmCreateCustomer"),
        _$table = $("#tblCustomers");

    var _$CustomerTable = _$table.DataTable({
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#customerSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;            
            filter.skipCount = data.start;
            filter.isActive = true;

            abp.ui.setBusy(_$table);
            _customerService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$CustomerTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'surname',
                sortable: true
            },
            {
                targets: 3,
                data: 'cityName',
                sortable: true
            },
            {
                targets: 4,
                data: 'cellPhone1',
                sortable: true,                
            },
            {
                targets: 5,
                data: 'phoneNumber1',
                sortable: true,
            },
            {
                targets: 6,
                data: 'isSeller',
                sortable: false,
                render: data => `<i class="fa ${data ? 'fa-check text-success' : 'fa-times text-danger'}"></i>`
            },
            {
                targets: 7,
                data: 'isBuyer',
                sortable: false,
                render: data => `<i class="fa ${data ? 'fa-check text-success' : 'fa-times text-danger'}"></i>`
            },
            {
                targets: 8,
                data: 'isActive',
                sortable: false,
                render: data => `<i class="fa ${data ? 'fa-check text-success' : 'fa-times text-danger'}"></i>`
            }
        ],        
        rowCallback: function (r, x) {                        
            $(r).attr("data-id", x.id);
        }
    });

    $("#tblCustomers").on('click', 'tbody tr', function () {
        $("#IsBusy").modal('show');
        let cusId = $(this).attr('data-id');
        $.post('/customers/GetCustomerDetails',
            {
                id: cusId
            },
            function (result, status) {
                $("#IsBusy").modal('hide');
                $("#mdlCustomerDetails .modal-body").html(result);                
                _cityService.getAll({}).done(function (result) {
                    result.items.forEach(c => {
                        let s = $("#mdlCustomerDetails .modal-body [name='CityId']");
                        $(s)
                            .append(`<option value="${c.id}">${c.name}</option>`)
                            .val($(s).attr('data-id'));
                    })
                })
                $("#mdlCustomerDetails #frmUpdateCustomer").submit(submitEdit);
                $("#mdlCustomerDetails").modal('show');
            })
    })

    $("#mdlCustomerDetails .modal-body").on('click', '.btnEdit', function () {        
        $("#mdlCustomerDetails .modal-body>div").addClass("d-none");
        $("#mdlCustomerDetails .modal-body #frmUpdateCustomer").removeClass("d-none");
    })
    $("#mdlCustomerDetails .modal-body").on('click', '.btnDelete', function () {
        let cusName = $(this).attr('data-name');
        let cusId = $(this).attr('data-id');       
        
        let d = $(`<div class="form-check"><label class="form-check-label mx-1">${l('AlsoDeleteRelatedEstates')}</label><input id="alsoDeleteEstates" type="checkbox" class="form-check-input"/></div>`)        
        sweetAlert({
            title: l('AreYouSureWantToDelete', cusName),
            buttons: [
                l('Cancel'),
                l('Yes')
            ],
            dangerMode: true,
            content: d[0] 
        }).then((value) => {            
            if (value) {
                $("#IsBusy").modal("show");
                $.post('customers/deleteCustomer/',
                    {
                        id: cusId,
                        withEstates: $("#alsoDeleteEstates").is(":checked")
                    },
                    function (data, status) {
                        console.log(data);
                        $("#IsBusy").modal("hide");
                        if (data.result.code == 0) {
                            sweetAlert("", data.result.msg, "success")
                            $("#mdlCustomerDetails .modal-body").empty();
                            $("#mdlCustomerDetails").modal("hide");
                            _$CustomerTable.ajax.reload();
                        } else {
                            sweetAlert("", data.result.msg, "error")
                        }
                        
                    }
                )
            }
            
        })
    })
    $("#mdlCustomerDetails .modal-body").on('click', '.returnEdit', function () {
        $("#mdlCustomerDetails .modal-body>div").removeClass("d-none");
        $("#mdlCustomerDetails .modal-body #frmUpdateCustomer").addClass("d-none");
    })

    function submitEdit(e) {
        e.preventDefault();
        let editForm = e.target;
        
        if (!$(editForm).valid()) {
            return false;
        }
        var customer = $(editForm).serializeFormToObject();
        customer.IsSeller = $(editForm).find("[name='IsSeller']").is(":checked");
        customer.IsBuyer = $(editForm).find("[name='IsBuyer']").is(":checked");
        customer.IsActive = $(editForm).find("[name='IsActive']").is(":checked");
        abp.ui.setBusy($(editForm));
        _customerService
            .update(customer)
            .done(function () {
                editForm.reset();
                abp.notify.info(l('UpdatedSuccessfully'));
                _$CustomerTable.ajax.reload();
                $("#mdlCustomerDetails").modal('hide');
            }).always(function () {
                abp.ui.clearBusy($(editForm));
            });
        return false;
    };
    

    _$form.on('submit', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return false;
        }

        var customer = _$form.serializeFormToObject();

        abp.ui.setBusy(_$form);
        _customerService
            .create(customer)
            .done(function () {
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$CustomerTable.ajax.reload();
                closeCreateSection();
            })
            .always(function () {
                abp.ui.clearBusy(_$form);
            });
    });
})