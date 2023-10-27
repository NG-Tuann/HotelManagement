(function ($) {
    //thong bao cho uan ly hoa don

    deleteReceiptionSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Xoá hóa đơn thành công',
            showHideTransition: 'slide',
            icon: 'warning',
            loaderBg: '#ffc107',
            position: 'bottom-left'
        })
    };

    changePasswordSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Đổi mật khẩu thành công',
            text: 'Mật khẩu đã được đổi mật khẩu thành công',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    registerSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Đăng ký thành công',
            text: 'Mật khẩu đã được gửi đến mail của nhân viên',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    loginSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Đăng nhập thành công',
            text: 'Hãy bắt đầu một ngày làm việc năng động đi nào bạn của tôi ơi.',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    createReceiptionSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Tạo hoá đơn và trả phòng thành công',
            text: 'Kiểm tra lại tình trạng phòng và danh sách các hoá đơn!',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    passwordSendToMailToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Xác thực thành công tài khoản',
            text: 'Mật khẩu mới đã được gửi đến tài khoản vừa xác thực. Vui lòng kiểm tra!',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    deleteReceiptionFailToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Xóa hóa đơn thất bại',
            showHideTransition: 'slide',
            icon: 'error',
            loaderBg: '#dc3545',
            position: 'bottom-left'
        })
    };

 
    // thong bao cho dich vu
    updateServiceSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Cập nhật thành công',
            text: 'Cập nhật danh sách dịch vụ thành công.',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    createBookingSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Đặt phòng thành công',
            text: 'Đặt phòng thành công. Kiểm tra lại từ danh sách đơn đặt.',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };

    deleteServiceSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Xoá dịch vụ thành công',
            showHideTransition: 'slide',
            icon: 'warning',
            loaderBg: '#ffc107',
            position: 'bottom-left'
        })
    };

    inValidUserToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Tài khoản này không tồn tại ',
            text: 'Tài khoản này không tồn tại hoặc chưa được đăng ký trước đó !',
            showHideTransition: 'slide',
            icon: 'warning',
            loaderBg: '#57c7d4',
            position: 'top-right'
        })
    };

    wrongPasswordToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Mật khẩu không trùng khớp với tài khoản',
            text: 'Mật khẩu không trùng khớp với tài khoản. Kiểm tra lại mật khẩu !',
            showHideTransition: 'slide',
            icon: 'warning',
            loaderBg: '#57c7d4',
            position: 'top-right'
        })
    };

    deleteServiceFailToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Xóa dịch vụ thất bại',
            showHideTransition: 'slide',
            icon: 'error',
            loaderBg: '#dc3545',
            position: 'bottom-left'
        })
    };

    createServiceSuccessToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Thêm dịch vụ thành công',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#28a745',
            position: 'bottom-left'
        })
    };
    // thong bao cho loai phong
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

    checkInFailToast = function () {
        'use strict';
        resetToastPosition();
        $.toast({
            heading: 'Nhận phòng ko thành công',
            text: 'Nhận phòng cho khách ko thành công. Hãy kiểm tra ngay thue bd !',
            showHideTransition: 'slide',
            icon: 'error',
            loaderBg: '#dc3545',
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