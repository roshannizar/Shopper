﻿var _0x18d9 = ['Newly\x20Added\x20Item(s)', 'insertCell', 'Rs:\x20', 'getElementById', 'orderid\x20', 'productid\x20', 'innerHTML', 'description\x20', 'quantity\x20', 'value', 'Edit', 'productid', 'orderId', 'Name', 'UnitPrice', 'Undo\x20Edit', 'unitprice\x20', 'DeleteBtn\x20', 'OrderId', 'push', 'Undo\x20Delete', 'SaveChanges', 'hidden', 'EditBtn\x20', 'Delete', 'ProductId', 'Quantity', 'updatedQuantity\x20', 'textContent', 'Quantity:\x20', 'updateTotalAmount\x20', 'Total\x20Amount:\x20Rs:\x20', 'length', 'customerId', 'orderIdTemp', 'CustomerId', 'replace', 'ajax', '../UpdateOrder', 'json', 'post', 'application/json', 'stringify', 'log', 'Save\x20changes\x20removed\x20successfully', 'productId', 'selectedIndex', 'options', 'UnitPriceText', 'QuantityText', 'orderItemCount', 'panel1', 'children', 'tempid', 'qty', 'tableForm', 'rows', 'cells', 'input', 'createElement', 'type', 'classList', 'add', 'btn', 'btn-sm', 'btn-danger', 'setAttribute', 'button', 'btn-warning', 'margin-left', 'number', 'form-control', 'col-md-6', 'disabled', 'insertRow', 'span', 'label-primary', 'appendChild']; (function (_0x2b0738, _0x3da20a) { var _0x438787 = function (_0x23c354) { while (--_0x23c354) { _0x2b0738['push'](_0x2b0738['shift']()); } }; _0x438787(++_0x3da20a); }(_0x18d9, 0x9f)); var _0x32c7 = function (_0x2e06c0, _0x44373a) { _0x2e06c0 = _0x2e06c0 - 0x0; var _0x3340d5 = _0x18d9[_0x2e06c0]; return _0x3340d5; }; var TempProduct = []; var breakCount = 0x0; var rowCount = 0x1; function EditOrders(_0x3a2dda) { var _0x106765 = document[_0x32c7('0x0')](_0x32c7('0x1') + _0x3a2dda)['innerHTML']; var _0x430832 = document[_0x32c7('0x0')](_0x32c7('0x2') + _0x3a2dda)[_0x32c7('0x3')]; var _0x268b26 = document['getElementById']('productName\x20' + _0x3a2dda)['innerHTML']; var _0x43a27c = document[_0x32c7('0x0')](_0x32c7('0x4') + _0x3a2dda)[_0x32c7('0x3')]; var _0x4d21a8 = document[_0x32c7('0x0')]('unitprice\x20' + _0x3a2dda)[_0x32c7('0x3')]; var _0x3677df = document[_0x32c7('0x0')](_0x32c7('0x5') + _0x3a2dda)[_0x32c7('0x3')]; var _0x464163 = document[_0x32c7('0x0')]('EditBtn\x20' + _0x3a2dda); if (_0x464163[_0x32c7('0x6')] === _0x32c7('0x7')) { document[_0x32c7('0x0')](_0x32c7('0x8'))[_0x32c7('0x6')] = _0x430832; document['getElementById']('id')['value'] = _0x3a2dda; document[_0x32c7('0x0')](_0x32c7('0x9'))[_0x32c7('0x6')] = _0x106765; document[_0x32c7('0x0')](_0x32c7('0xa'))[_0x32c7('0x6')] = _0x268b26; document[_0x32c7('0x0')]('description')[_0x32c7('0x6')] = _0x43a27c; document['getElementById'](_0x32c7('0xb'))[_0x32c7('0x6')] = _0x4d21a8; document[_0x32c7('0x0')]('Quantity')[_0x32c7('0x6')] = _0x3677df; _0x464163['value'] = _0x32c7('0xc'); } else { _0x464163[_0x32c7('0x6')] = _0x32c7('0x7'); } } function DeleteOrderItem(_0x4992ac) { var _0x1be04a = document[_0x32c7('0x0')](_0x32c7('0x1') + _0x4992ac)[_0x32c7('0x3')]; var _0x2bfd10 = document[_0x32c7('0x0')](_0x32c7('0x2') + _0x4992ac)[_0x32c7('0x3')]; var _0xdd4c6f = document[_0x32c7('0x0')](_0x32c7('0xd') + _0x4992ac)['innerHTML']; var _0x253d6e = document[_0x32c7('0x0')](_0x32c7('0x5') + _0x4992ac)[_0x32c7('0x3')]; var _0xb4f9ce = document['getElementById'](_0x32c7('0xe') + _0x4992ac); var _0x1d5fec = { 'Id': 0x0, 'ProductId': 0x0, 'UnitPrice': 0x0, 'Quantity': 0x0, 'OrderId': 0x0, 'IsDeleted': !![] }; if (_0xb4f9ce[_0x32c7('0x6')] === 'Delete') { _0x1d5fec['Id'] = _0x4992ac; _0x1d5fec['ProductId'] = parseInt(_0x2bfd10); _0x1d5fec[_0x32c7('0xf')] = parseInt(_0x1be04a); _0x1d5fec['Quantity'] = parseInt(_0x253d6e); _0x1d5fec[_0x32c7('0xb')] = parseInt(_0xdd4c6f); TempProduct[_0x32c7('0x10')](_0x1d5fec); _0xb4f9ce[_0x32c7('0x6')] = _0x32c7('0x11'); document[_0x32c7('0x0')](_0x32c7('0x12'))[_0x32c7('0x13')] = ![]; document['getElementById'](_0x32c7('0x14') + _0x4992ac)[_0x32c7('0x13')] = !![]; } else { _0xb4f9ce['value'] = _0x32c7('0x15'); } } function ConfirmOrderChanges() { var _0x33f491 = { 'Id': 0x0, 'ProductId': 0x0, 'UnitPrice': 0x0, 'Quantity': 0x0, 'OrderId': 0x0, 'IsDeleted': ![] }; _0x33f491['Id'] = parseInt(document['getElementById']('id')[_0x32c7('0x6')]); _0x33f491[_0x32c7('0x16')] = parseInt(document['getElementById']('productid')[_0x32c7('0x6')]); _0x33f491['UnitPrice'] = parseInt(document[_0x32c7('0x0')](_0x32c7('0xb'))[_0x32c7('0x6')]); _0x33f491[_0x32c7('0x17')] = parseInt(document[_0x32c7('0x0')]('Quantity')['value']); _0x33f491['OrderId'] = parseInt(document['getElementById'](_0x32c7('0x9'))[_0x32c7('0x6')]); document[_0x32c7('0x0')](_0x32c7('0x18') + _0x33f491['Id'])[_0x32c7('0x19')] = _0x32c7('0x1a') + _0x33f491[_0x32c7('0x17')]; document[_0x32c7('0x0')](_0x32c7('0x1b') + _0x33f491['Id'])['textContent'] = _0x32c7('0x1c') + parseInt(document[_0x32c7('0x0')](_0x32c7('0x17'))['value']) * parseInt(document[_0x32c7('0x0')](_0x32c7('0xb'))[_0x32c7('0x6')]); document[_0x32c7('0x0')](_0x32c7('0x14') + _0x33f491['Id'])[_0x32c7('0x6')] = _0x32c7('0xc'); var _0x251a1f = ![]; for (var _0x20ffde = 0x0; _0x20ffde < TempProduct[_0x32c7('0x1d')]; _0x20ffde++) { var _0x155016 = TempProduct[_0x20ffde][_0x32c7('0x16')]; if (parseInt(_0x155016) === parseInt(_0x33f491[_0x32c7('0x16')])) { var _0x427eae = parseInt(TempProduct[_0x20ffde]['Quantity']); var _0x323aee = parseInt(_0x33f491[_0x32c7('0x17')]); var _0x257719 = _0x427eae + _0x323aee; TempProduct[_0x20ffde][_0x32c7('0x17')] = parseInt(_0x257719); _0x251a1f = !![]; break; } } if (TempProduct[_0x32c7('0x1d')] == 0x0) { TempProduct['push'](_0x33f491); } else if (_0x251a1f == ![]) { TempProduct[_0x32c7('0x10')](_0x33f491); } document[_0x32c7('0x0')]('SaveChanges')[_0x32c7('0x13')] = ![]; } function Confirm() { var _0x5a93df = new Date(); var _0x3d4a98 = JSON['stringify'](_0x5a93df); var _0x4086e9 = document['getElementById'](_0x32c7('0x1e'))[_0x32c7('0x3')]; var _0x5cb986 = document['getElementById'](_0x32c7('0x1f'))['value']; var _0x274208 = { 'Id': 0x0, 'CustomerId': 0x0, 'Date': null, 'OrderItems': TempProduct }; _0x274208['Id'] = parseInt(_0x5cb986); _0x274208[_0x32c7('0x20')] = parseInt(_0x4086e9); _0x274208['Date'] = _0x3d4a98[_0x32c7('0x21')](/^"(.*)"$/, '$1'); $[_0x32c7('0x22')]({ 'url': _0x32c7('0x23'), 'dataType': _0x32c7('0x24'), 'type': _0x32c7('0x25'), 'contentType': _0x32c7('0x26'), 'data': JSON[_0x32c7('0x27')](_0x274208), 'processData': ![], 'success': function (_0x451f0c, _0x54aedc, _0x1cd1ae) { console[_0x32c7('0x28')](_0x451f0c, _0x54aedc, _0x1cd1ae); }, 'error': function (_0x22af18, _0x52acc5, _0xe79f52) { console[_0x32c7('0x28')](_0x22af18, _0x52acc5, _0xe79f52); } }); } function EraseChanges() { TempProduct = []; document[_0x32c7('0x0')](_0x32c7('0x12'))[_0x32c7('0x13')] = !![]; alert(_0x32c7('0x29')); } function PlaceNewOrder(_0x222ddb) { var _0x37b435 = document[_0x32c7('0x0')](_0x32c7('0x2a')); var _0x57072d = _0x37b435['options'][_0x37b435[_0x32c7('0x2b')]][_0x32c7('0x6')]; var _0x37b394 = _0x37b435[_0x32c7('0x2c')][_0x37b435[_0x32c7('0x2b')]][_0x32c7('0x19')]; var _0x271ba9 = document[_0x32c7('0x0')]('descriptionText')[_0x32c7('0x6')]; var _0x330a14 = document[_0x32c7('0x0')](_0x32c7('0x2d'))[_0x32c7('0x6')]; var _0x2f823b = document['getElementById'](_0x32c7('0x2e'))[_0x32c7('0x6')]; var _0x1fecdf = document['getElementById'](_0x32c7('0x2f'))[_0x32c7('0x3')]; var _0x2ecb2e = { 'Id': 0x0, 'ProductId': 0x0, 'UnitPrice': 0x0, 'Quantity': 0x0, 'OrderId': 0x0, 'IsDeleted': ![] }; _0x2ecb2e[_0x32c7('0x16')] = parseInt(_0x57072d); _0x2ecb2e[_0x32c7('0xb')] = parseInt(_0x330a14); _0x2ecb2e[_0x32c7('0x17')] = parseInt(_0x2f823b); _0x2ecb2e['OrderId'] = parseInt(_0x222ddb); var _0x54fcf1 = ![]; var _0x59e4fb = 0x0; var _0x20f5fe = ![]; for (_0x2a1cf6 = 0x0; _0x2a1cf6 < parseInt(_0x1fecdf); _0x2a1cf6++) { var _0x56c06c = document[_0x32c7('0x0')](_0x32c7('0x30')); var _0x9c6b65 = _0x56c06c[_0x32c7('0x31')][_0x59e4fb][_0x32c7('0x31')][0x0][_0x32c7('0x31')][0x0][_0x32c7('0x31')][_0x32c7('0x8')][_0x32c7('0x3')]; if (_0x9c6b65 === _0x57072d) { var _0x4ec0dc = _0x56c06c[_0x32c7('0x31')][_0x59e4fb][_0x32c7('0x31')][0x0]['children'][0x0][_0x32c7('0x31')][_0x32c7('0x32')][_0x32c7('0x3')]; var _0x1d2ffe = document[_0x32c7('0x0')](_0x32c7('0x5') + _0x4ec0dc)['innerHTML']; _0x2ecb2e[_0x32c7('0x17')] = _0x2ecb2e[_0x32c7('0x17')] + parseInt(_0x1d2ffe); _0x2ecb2e[_0x32c7('0x16')] = parseInt(_0x9c6b65); _0x2ecb2e['Id'] = parseInt(_0x4ec0dc); document['getElementById'](_0x32c7('0x5') + _0x4ec0dc)[_0x32c7('0x3')] = _0x2ecb2e['Quantity']; document[_0x32c7('0x0')](_0x32c7('0x18') + _0x4ec0dc)[_0x32c7('0x3')] = _0x32c7('0x1a') + _0x2ecb2e[_0x32c7('0x17')]; _0x20f5fe = !![]; break; } _0x59e4fb += 0x2; } for (var _0x2a1cf6 = 0x0; _0x2a1cf6 < TempProduct[_0x32c7('0x1d')]; _0x2a1cf6++) { var _0x3ec51f = TempProduct[_0x2a1cf6]['ProductId']; if (parseInt(_0x3ec51f) === parseInt(_0x57072d)) { var _0x596e83 = TempProduct[_0x2a1cf6][_0x32c7('0xb')]; var _0x1d2ffe = parseInt(TempProduct[_0x2a1cf6]['Quantity']); var _0x5c2e5c = parseInt(_0x2f823b); var _0x4ff202 = _0x1d2ffe + _0x5c2e5c; if (_0x20f5fe == ![]) { document[_0x32c7('0x0')](_0x32c7('0x33') + (_0x2a1cf6 + 0x1))['value'] = _0x4ff202; document[_0x32c7('0x0')](_0x32c7('0x34'))[_0x32c7('0x35')][_0x2a1cf6 + 0x1][_0x32c7('0x36')][0x4]['innerHTML'] = 'Rs:\x20' + parseInt(_0x4ff202) * parseInt(_0x596e83); } TempProduct[_0x2a1cf6]['Quantity'] = parseInt(_0x4ff202); _0x54fcf1 = !![]; break; } } if (_0x20f5fe == !![] && _0x54fcf1 == ![]) { TempProduct['push'](_0x2ecb2e); } else if (TempProduct['length'] == 0x0) { TempProduct[_0x32c7('0x10')](_0x2ecb2e); CreateTableRow(_0x37b394, _0x271ba9, _0x330a14, _0x2f823b); rowCount++; } else if (_0x54fcf1 == ![]) { TempProduct[_0x32c7('0x10')](_0x2ecb2e); CreateTableRow(_0x37b394, _0x271ba9, _0x330a14, _0x2f823b); rowCount++; } } function CreateTableRow(_0x4fc5bc, _0x119925, _0x56cf1f, _0x13d16c) { var _0x40797d = document[_0x32c7('0x0')](_0x32c7('0x34')); var _0x16f7c8 = document['createElement'](_0x32c7('0x37')); var _0x2c25d5 = document['createElement'](_0x32c7('0x37')); var _0x298b7b = document[_0x32c7('0x38')](_0x32c7('0x37')); _0x16f7c8['setAttribute'](_0x32c7('0x39'), 'button'); _0x16f7c8['setAttribute'](_0x32c7('0x6'), _0x32c7('0x15')); _0x16f7c8[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x3c')); _0x16f7c8[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x3d')); _0x16f7c8['classList'][_0x32c7('0x3b')](_0x32c7('0x3e')); _0x2c25d5[_0x32c7('0x3f')](_0x32c7('0x39'), _0x32c7('0x40')); _0x2c25d5[_0x32c7('0x3f')](_0x32c7('0x6'), _0x32c7('0x7')); _0x2c25d5[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x3c')); _0x2c25d5[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x3d')); _0x2c25d5['classList']['add'](_0x32c7('0x41')); _0x16f7c8[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x42')); _0x298b7b[_0x32c7('0x3f')](_0x32c7('0x39'), _0x32c7('0x43')); _0x298b7b['setAttribute']('id', _0x32c7('0x33') + rowCount); _0x298b7b[_0x32c7('0x3a')][_0x32c7('0x3b')](_0x32c7('0x44')); _0x298b7b['classList'][_0x32c7('0x3b')](_0x32c7('0x45')); _0x298b7b[_0x32c7('0x46')] = !![]; if (breakCount == 0x0) { var _0x199a00 = _0x40797d[_0x32c7('0x47')](0x0); var _0x590faa = document[_0x32c7('0x38')](_0x32c7('0x48')); _0x590faa[_0x32c7('0x3a')][_0x32c7('0x3b')]('badge'); _0x590faa['classList']['add'](_0x32c7('0x49')); var _0x2ea8d6 = _0x199a00['insertCell'](0x0); _0x2ea8d6[_0x32c7('0x4a')](_0x590faa); _0x2ea8d6[_0x32c7('0x3')] = _0x32c7('0x4b'); } breakCount++; var _0x199a00 = _0x40797d[_0x32c7('0x47')](rowCount); var _0x538be0 = _0x199a00[_0x32c7('0x4c')](0x0); var _0x757aa6 = _0x199a00[_0x32c7('0x4c')](0x1); _0x757aa6['colSpan'] = 0x2; var _0x304dba = _0x199a00[_0x32c7('0x4c')](0x2); var _0x47fb1a = _0x199a00[_0x32c7('0x4c')](0x3); var _0x164c7b = _0x199a00[_0x32c7('0x4c')](0x4); var _0x1c4c33 = _0x199a00[_0x32c7('0x4c')](0x5); var _0x41453b = _0x199a00[_0x32c7('0x4c')](0x6); _0x41453b[_0x32c7('0x4a')](_0x16f7c8); _0x1c4c33['appendChild'](_0x2c25d5); _0x47fb1a[_0x32c7('0x4a')](_0x298b7b); _0x538be0[_0x32c7('0x3')] = _0x4fc5bc; _0x757aa6[_0x32c7('0x3')] = _0x119925; _0x304dba['innerHTML'] = _0x32c7('0x4d') + _0x56cf1f; _0x298b7b['value'] = _0x13d16c; _0x164c7b['innerHTML'] = 'Rs:\x20' + parseInt(_0x13d16c) * parseInt(_0x56cf1f); _0x1c4c33[_0x32c7('0x4a')](_0x2c25d5); }