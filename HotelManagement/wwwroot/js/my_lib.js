$(document).ready(function () {
        // Room
        $('.datepicker').datepicker({
            setDate: new Date(),
            format: 'dd/mm/yyyy',
            todayHighlight: true,
            autoclose: true,
            startDate: 0,
            minDate: 0,
            maxDate: new Date()
        });
        $('.datepicker_from').datepicker({
        setDate: new Date(),
            format: 'dd/mm/yyyy',
            todayHighlight: true,
            autoclose: true,
            startDate: '+1d',
            minDate: new Date(),

        });
        $('.datepicker_to').datepicker({
            format: 'dd/mm/yyyy',
            todayHighlight: true,
            autoclose: true,
            startDate: '+2d',
            minDate: 0,

        });

        $("#start").on("change", function (e) {
            var secondDate = $("#start").datepicker("getDate");
            secondDate.setDate(secondDate.getDate() + 1);
            $("#end").datepicker("setStartDate", secondDate);
            $("#end").datepicker("setDate", secondDate);
        });


        $("#end").on("change", function (e) {
            var firstDate = $("#end").datepicker("getDate");
            firstDate.setDate(firstDate.getDate() - 1);
            $("#start").datepicker("setStartDate", firstDate);
            $("#start").datepicker("setDate", firstDate);
        });

        $('#create_booking').click(function () {
        showSuccessToast();
            console.log("Hello");
        });

        $('.dropdown .room').click(function () {
            var roomCheckIn = $(this).attr('id');
            console.log(roomCheckIn);
            $('#roomCheck').val(roomCheckIn);
        });

        $('#create_check_in_btn').click(function () {
            var roomCheck = $('#roomCheck').val();
            console.log(roomCheck);
            $('#' + roomCheck).removeClass("custom_room_available");
            console.log("click");
            $('#' + roomCheck).addClass("custom_room_check_in");
            $('#checkin_' + roomCheck).addClass("disabled");
            $('#' + roomCheck + "_checkIn").html('<div class="stayInfo"></div>');
            console.log("#" + roomCheck + "_checkIn");
            $('.stayInfo').text('16h - 20h');
        });

        // support create room at chosen floor
        $('.dropdown-menu .floor-number').click(function () {
            var floorNumber = $(this).attr('id');
            console.log(floorNumber);
            $('#floor_number').html(floorNumber);
            $('#floor_number_id').val(floorNumber);
        });

        // support get room id for delete room
        $('.dropdown-menu .dropdown-item').click(function () {
            var roomId = $(this).attr('id');
            console.log(roomId);
            $('#delete_room').html(roomId);
            $('#delete_room_id').val(roomId);
        });

        /* ajax support update room */
        $('.dropdown-menu .dropdown-item').click(function () {
            var roomId = $(this).attr('id');
            console.log(roomId);
            $.ajax({
                    type: 'GET',
                    data: {
                        room_id: roomId
                    },
                    url: '/room/update',
                    success: function (room) {
                        console.log(room);

                        $('#room_id_update').val(room.maphong);
                        $('#room_number_update').val(room.phongSo);
                        $('#floor_number_update').val(room.maTang);
                        $('#room_type_id_update').val(room.maLp);
                        $('#room_status_update').val(room.tinhTrang);
                    }
             });
        
        });

        // support get floor id for delete room
        $('.dropdown-menu .floor-number').click(function () {
            var floorNumber = $(this).attr('id');
            console.log("Tang thu: "+floorNumber);
            $('#delete_floor').html(floorNumber);
            $('#delete_floor_id').val(floorNumber);
        });

        // RoomType
        // support get floor id for delete room
        $('.loai_phong_action a').click(function () {
            var maLp = $(this).attr('id');
            console.log("Ma loai phong: " + maLp);

            $.ajax({
                type: 'GET',
                data: {
                    ma_lp: maLp
                },
                url: '/roomtype/update',
                success: function (roomType) {
                    console.log(roomType);

                    $('#loai_phong_update').val(roomType.loaiPhong1);
                    $('#khong_gian_update').val(roomType.khongGian);
                    $('#so_giuong_update').val(roomType.soGiuong);
                    $('#so_nguoi_update').val(roomType.soNguoi);
                    $('#update_roomtype_id').val(roomType.malp);

                    $('#gia_theo_gio_update').val(roomType.maGiaNavigation.giaTheoGio);
                    $('#gia_theo_ngay_update').val(roomType.maGiaNavigation.giaTheoNgay);
                    $('#gia_theo_tuan_update').val(roomType.maGiaNavigation.giaTheoTuan);
                    $('#gia_theo_thang_update').val(roomType.maGiaNavigation.giaTheoThang);
                    $('#ngay_hieu_luc_bd_update').val(roomType.maGiaNavigation.ngayHieuLucBd);
                    $('#ngay_hieu_luc_kt_update').val(roomType.maGiaNavigation.ngayHieuLucKt);


                    $('#qua_1h_update').val(roomType.maGiaNavigation.qua_1h);
                    $('#qua_2h_update').val(roomType.maGiaNavigation.qua_2h);
                    $('#truoc_3h_update').val(roomType.maGiaNavigation.truoc_3h);
                    $('#truoc_4h_update').val(roomType.maGiaNavigation.truoc_4h);
                    $('#update_price_id').val(roomType.maGiaNavigation.magia);
                }
            });
        });
    });