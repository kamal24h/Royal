(function ($) {
    var _cityService = abp.services.app.city,
        l = abp.localization.getSource('RoyalEstate'),
        _$modal = $('#mdlCreateCity'),
        _$form = _$modal.find('form'),
        _$table = $('#tblCities');

    var _$CityTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#citySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _cityService.getAll(filter).done(function (result) {
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
                action: () => _$CityTable.draw(false)
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
                data: 'provinceName',
                sortable: true
            },
            {
                targets: 3,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary btnEditCity" data-cityId="${row.id}" data-toggle="modal" data-target="#mdlEditCity">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger btnDeleteCity" data-cityId="${row.id}" data-cityName="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $('#citySearchForm select').change(function() {
        _$CityTable.ajax.reload();
    })

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var city = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _cityService
            .create(city)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$CityTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });




    $(document).on('click', '.btnDeleteCity', function () {
        var cityId = $(this).attr("data-cityId");
        var cityName = $(this).attr('data-cityName');

        deleteCity(cityId, cityName);
    });

    $(document).on('click', '.btnEditCity', function (e) {
        var cityId = $(this).attr("data-cityId");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Cities/EditModal/?id=' + cityId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#mdlEditCity div.modal-content').html(content);
            },
            error: function (e) {
                console.log(e)
            }
        })
    });

    abp.event.on('city.edited', (data) => {
        _$CityTable.ajax.reload();
    });

    function deleteCity(cityId, cityName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                cityName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _cityService.delete({
                        id: cityId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$CityTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$CityTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$CityTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
