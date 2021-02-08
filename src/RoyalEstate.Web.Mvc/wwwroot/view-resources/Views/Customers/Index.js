$(() => {
    let _customerService = abp.services.app.customer,
        l = abp.localization.getSource('RoyalEstate'),
        _$form = $("#frmCreateCustomer"),
        _$table = $("#tblCustomers");

    var _$CustomerTable = _$table.DataTable({
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#customerSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _customerService.getAll(filter).done(function (result) {
                console.log(result);
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
                data: 'cityname',
                sortable: true
            },
            {
                targets: 4,
                data: 'creationtime',
                sortable: true
            },
            {
                targets: 5,
                data: 'isSeller',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 6,
                data: 'isBuyer',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 7,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            }
        ]
    });

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