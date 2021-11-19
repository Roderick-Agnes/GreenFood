$('input[name="paymentMethod"]').off('click').on('click', function () {
    if ($(this).val() == 'nl') {
        $('.boxContent').hide();
        $('#nganluongContent').show();
    }
    else if ($(this).val() == 'bank') {
        $('.boxContent').hide();
        $('#bankContent').show();
    }
    else {
        $('#nganluongContent').hide();
        $('#bankContent').hide();
    }
});