(function ($) {
    var _estateTypeService = abp.services.app.estatetype,
        l = abp.localization.getSource('RoyalEstate'),
        _$modal = $('#EstateTypeCreateModal'),        
        _$form = _$modal.find('form'),
        _$table = $('#EstateTypeTable');

    var _$EstateTypeTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#EstateTypeSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _estateTypeService.getAll(filter).done(function (result) {
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
                action: () => _$EstateTypeTable.draw(false)
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
                data: 'Name',
                sortable: false
            },
            {
                targets: 2,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-role" data-role-id="${row.id}" data-toggle="modal" data-target="#EstateTypeEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-role" data-role-id="${row.id}" data-role-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        //var role = _$form.serializeFormToObject();
        //role.grantedPermissions = [];
        //var _$permissionCheckboxes = _$form[0].querySelectorAll("input[name='permission']:checked");
        //if (_$permissionCheckboxes) {
        //    for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
        //        var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
        //        role.grantedPermissions.push(_$permissionCheckbox.val());
        //    }
        //}

        abp.ui.setBusy(_$modal);
        _estateTypeService
            .create(estatetype)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$EstateTypeTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-EstateType', function () {
        var EstateTypeId = $(this).attr("data-EstateType-id");
        var EstateTypeName = $(this).attr('data-EstateType-name');

        deleteEstateType(EstateTypeId, EstateTypeName);
    });

    $(document).on('click', '.edit-EstateType', function (e) {
        var EstateTypeId = $(this).attr("data-EstateType-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Estates/EditModal?EstateTypeId=' + roleId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#EstateTypeEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('EstateType.edited', (data) => {
        _$EstateTypeTable.ajax.reload();
    });

    function deleteEstateType(EstateTypeId, EstateTypeName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                EstateTypeName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _estateTypeService.delete({
                        id: roleId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$EstateTypeTable.ajax.reload();
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
        _$EstateTypeTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$EstateTypeTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
