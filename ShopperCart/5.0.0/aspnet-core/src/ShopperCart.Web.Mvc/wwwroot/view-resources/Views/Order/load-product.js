﻿var _0x4ea9 = ['GET', '../../product/GetProductById/', 'send', '--\x20Please\x20choose\x20a\x20product\x20--', 'onreadystatechange', 'readyState', 'status', 'parse', 'responseText', 'result', 'NewOrder', 'getElementById', 'hiddenQuantity', 'hidden', 'description', 'unitprice', 'quantity', 'disabled', 'quantityInStock', 'descriptionText', 'value', 'UnitPriceText', 'innerHTML', 'Product\x20not\x20found!', 'log', 'No\x20product\x20found!', 'open']; (function (_0x4cdcdf, _0x495060) { var _0x4b315c = function (_0x2d152c) { while (--_0x2d152c) { _0x4cdcdf['push'](_0x4cdcdf['shift']()); } }; _0x4b315c(++_0x495060); }(_0x4ea9, 0xdb)); var _0x3eeb = function (_0x100349, _0x1ba390) { _0x100349 = _0x100349 - 0x0; var _0x3ea083 = _0x4ea9[_0x100349]; return _0x3ea083; }; function LoadProducts(_0x30091a, _0x17ec8b) { var _0x573948 = new XMLHttpRequest(); if (!(_0x30091a === _0x3eeb('0x0'))) { _0x573948[_0x3eeb('0x1')] = function () { if (this[_0x3eeb('0x2')] == 0x4 && this[_0x3eeb('0x3')] == 0xc8) { var _0x4c3599 = JSON[_0x3eeb('0x4')](this[_0x3eeb('0x5')]); var _0x18b1ea = _0x4c3599[_0x3eeb('0x6')]; if (_0x18b1ea != undefined || _0x18b1ea != null) { if (_0x17ec8b === _0x3eeb('0x7')) { document[_0x3eeb('0x8')](_0x3eeb('0x9'))[_0x3eeb('0xa')] = ![]; document['getElementById'](_0x3eeb('0xb'))['innerHTML'] = _0x18b1ea[_0x3eeb('0xb')]; document[_0x3eeb('0x8')](_0x3eeb('0xc'))['innerHTML'] = _0x18b1ea['unitPrice']; document['getElementById'](_0x3eeb('0xd'))[_0x3eeb('0xe')] = ![]; document[_0x3eeb('0x8')](_0x3eeb('0xf'))['innerHTML'] = _0x18b1ea['quantity']; } else { document[_0x3eeb('0x8')](_0x3eeb('0x10'))[_0x3eeb('0x11')] = _0x18b1ea['description']; document[_0x3eeb('0x8')](_0x3eeb('0x12'))[_0x3eeb('0x11')] = parseInt(_0x18b1ea['unitPrice']); } } else { document[_0x3eeb('0x8')](_0x3eeb('0xb'))[_0x3eeb('0x13')] = _0x3eeb('0x14'); document[_0x3eeb('0x8')](_0x3eeb('0xc'))['innerHTML'] = 'Product\x20not\x20found!'; document[_0x3eeb('0x8')]('hiddenQuantity')[_0x3eeb('0xa')] = !![]; console[_0x3eeb('0x15')](_0x3eeb('0x16')); } } }; if (_0x17ec8b === _0x3eeb('0x7')) { _0x573948[_0x3eeb('0x17')]('GET', '../product/GetProductById/' + parseInt(_0x30091a), !![]); } else { _0x573948[_0x3eeb('0x17')](_0x3eeb('0x18'), _0x3eeb('0x19') + parseInt(_0x30091a), !![]); } _0x573948[_0x3eeb('0x1a')](); } }