var values = {
    init: function () {
        values.registerEvents();
    },
    registerEvents: function () {
        $('.btn_radio').off('click').on('click', function (e) {
            e.preventDefault();

            var btn = $(this);
             //item1;
            if ($('#rdoBank').is(":checked")) {
                var item1 = $('#rdoBank').val();
                var valuePaymentMethod = item1.toString();
                var valueBankCode = "BIDV";
                $.ajax({
                    url: "/GioHang/GetValuePay",
                    type: "POST",
                    data: {
                        valuePaymentMethod: valuePaymentMethod,
                        valueBankCode: valueBankCode
                    },
                    dataType: "json"
                    ,
                    success: function (response) {
                        ////success
                        alert(response);
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }




                });
            }

            
        });
    }
}
values.init();