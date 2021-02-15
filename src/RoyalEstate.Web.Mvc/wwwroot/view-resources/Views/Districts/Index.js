(function ($) {
    var _districtService = abp.services.app.district,
        l = abp.localization.getSource('RoyalEstate'),
        _$modal = $('#mdlCreateDistrict'),
        _$form = _$modal.find('form'),
        _$table = $('#tblDistricts');

    var _$districtTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#districtSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _districtService.getAll(filter).done(function (result) {
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
                action: () => _$districtTable.draw(false)
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
                data: 'cityName',
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
                        `   <button type="button" class="btn btn-sm bg-secondary btnEditdistrict" data-districtId="${row.id}" data-toggle="modal" data-target="#mdlEditdistrict">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger btnDeletedistrict" data-districtId="${row.id}" data-districtName="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $('#districtSearchForm select').change(function() {
        _$districtTable.ajax.reload();
    })

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var district = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _districtService
            .create(district)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$districtTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });




    $(document).on('click', '.btnDeletedistrict', function () {
        var districtId = $(this).attr("data-districtId");
        var districtName = $(this).attr('data-districtName');

        deletedistrict(districtId, districtName);
    });

    $(document).on('click', '.btnEditdistrict', function (e) {
        var districtId = $(this).attr("data-districtId");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Districts/EditModal/?id=' + districtId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#mdlEditdistrict div.modal-content').html(content);
            },
            error: function (e) {
                console.log(e)
            }
        })
    });

    abp.event.on('district.edited', (data) => {
        _$districtTable.ajax.reload();
    });

    function deletedistrict(districtId, districtName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                districtName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _districtService.delete({
                        id: districtId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$districtTable.ajax.reload();
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
        _$districtTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$districtTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
