(function($) {
  updateRoomTypeSuccessToast = function() {
    'use strict';
      resetToastPosition();
    $.toast({
      heading: 'Cập nhật thành công',
      text: 'Loại phòng cùng với cài đặt giá đã được cập nhật thành công, hãy kiểm tra.',
      showHideTransition: 'slide',
      icon: 'success',
      loaderBg: '#28a745',
      position: 'bottom-left'
    })
  };

    updateDepositSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Cập nhật tiền cọc thành công',
            text: 'Cập nhật tiền cọc thành công cho đơn đặt. Hãy kiểm tra đơn đặt phòng !',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    updateDepositFailToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Cập nhật tiền cọc không thành công',
            text: 'Cập nhật tiền cọc không thành công. Hãy kiểm tra lại trạng thái đơn đặt phòng !',
            showHideTransition: 'slide',
            icon: 'error',
            loaderBg: '#dc3545',
            position: 'bottom-left'
        })
    };


    checkInSuccessToast = function() {
    'use strict';
      resetToastPosition();
    $.toast({
        heading: 'Nhận phòng thành công',
        text: 'Nhận phòng cho khách thành công. Hãy kiểm tra trạng thái của các phòng đã nhận !',
      showHideTransition: 'slide',
      icon: 'success',
      loaderBg: '#28a745',
      position: 'bottom-left'
    })
  };

  deleteRoomTypeSuccessToast = function() {
    'use strict';
    resetToastPosition();
    $.toast({
        heading: 'Xoá phòng thành công',
        text: 'Hãy kiểm tra lại danh sách loại phòng và các phòng trực thuộc loại phòng vừa xoá.',
      showHideTransition: 'slide',
      icon: 'warning',
      loaderBg: '#ffc107',
      position: 'bottom-left'
    })
  };

    deleteRoomTypeFailToast = function() {
    'use strict';
    resetToastPosition();
    $.toast({
      heading: 'Xoá loại phòng thất bại',
      text: 'Cập nhật loại phòng cho các phòng liên quan trước khi xoá loại phòng này.',
      showHideTransition: 'slide',
      icon: 'error',
      loaderBg: '#dc3545',
      position: 'bottom-left'
    })
  };

  createRoomTypeSuccessToast = function() {
    'use strict';
      resetToastPosition();
    $.toast({
      heading: 'Thêm thành công',
      text: 'Loại phòng cùng với cài đặt giá đã được thêm thành công, hãy kiểm tra.',
      showHideTransition: 'slide',
      icon: 'success',
      loaderBg: '#28a745',
      position: 'bottom-left'
    })
  };
  showInfoToast = function() {
    'use strict';
      resetToastPosition();
    $.toast({
      heading: 'Info',
      text: 'And these were just the basic demos! Scroll down to check further details on how to customize the output.',
      showHideTransition: 'slide',
      icon: 'info',
      loaderBg: '#46c35f',
      position: 'top-right'
    })
  };
  showWarningToast = function() {
    'use strict';
    resetToastPosition();
    $.toast({
      heading: 'Warning',
      text: 'And these were just the basic demos! Scroll down to check further details on how to customize the output.',
      showHideTransition: 'slide',
      icon: 'warning',
      loaderBg: '#57c7d4',
      position: 'top-right'
    })
  };
  showDangerToast = function() {
    'use strict';
    resetToastPosition();
    $.toast({
      heading: 'Danger',
      text: 'And these were just the basic demos! Scroll down to check further details on how to customize the output.',
      showHideTransition: 'slide',
      icon: 'error',
      loaderBg: '#f2a654',
      position: 'top-right'
    })
  };
  showToastPosition = function(position) {
    'use strict';
    resetToastPosition();
    $.toast({
      heading: 'Positioning',
      text: 'Specify the custom position object or use one of the predefined ones',
      position: String(position),
      icon: 'info',
      stack: false,
      loaderBg: '#f96868'
    })
  }
  showToastInCustomPosition = function() {
    'use strict';
    resetToastPosition();
    $.toast({
      heading: 'Custom positioning',
      text: 'Specify the custom position object or use one of the predefined ones',
      icon: 'info',
      position: {
        left: 120,
        top: 120
      },
      stack: false,
      loaderBg: '#f96868'
    })
  }
  resetToastPosition = function() {
    $('.jq-toast-wrap').removeClass('bottom-left bottom-right top-left top-right mid-center'); // to remove previous position class
    $(".jq-toast-wrap").css({
      "top": "",
      "left": "",
      "bottom": "",
      "right": ""
    }); //to remove previous position style
  }
})(jQuery);