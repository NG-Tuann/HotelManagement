$(document).ready(function() {
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

        $("a[data-id=xoa_phong]").click(function () {
            var roomId = $(this).attr('id');
            console.log(roomId);
            $('#delete_room').text(roomId);
            $('#delete_room_id').val(roomId);
        });

        // cap nhat phong

        $("a[data-id=cap_nhat_phong]").click(function () {
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

        // BOOKING

        // support get floor id for delete room

        $('.dropdown-menu .floor-number').click(function () {
            var floorNumber = $(this).attr('id');
            console.log("Tang thu: "+floorNumber);
            $('#delete_floor').html(floorNumber);
            $('#delete_floor_id').val(floorNumber);
        });

        // RoomType
        // support get roomtype id for delete room

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

        // support get roomtype id for delete
        
        $('.loai_phong_action a').click(function () {
            var maLp = $(this).attr('id');
            console.log("Ma loai phong: " + maLp);
            $.ajax({
            type: 'GET',
            data: {
                ma_lp: maLp
            },
            url: '/roomtype/delete',
                success: function (roomType) {
                    console.log(roomType);
                    $('#delete_room_type').text(roomType.loaiPhong1);
                    $('#delete_room_type_id').val(roomType.malp);
                }
            });
        });

    //Service
        // support get service id for delete
    $('.dich_vu_action a').click(function () {
        var madv = $(this).attr('id');
        console.log("Ma dich vu: " + madv);
        $.ajax({
            type: 'GET',
            data: {
                ma_dv: madv
            },
            url: '/service/delete',
            success: function (service) {
                console.log(service);
                $('#delete_service').text(service.tenDv);
                $('#delete_service_id').val(service.madv);
            }
        });
    });
    // support get id for update service
    $('.dich_vu_action a').click(function () {
        var maDv = $(this).attr('id');
        console.log("Ma dich vu: " + maDv);

        $.ajax({
            type: 'GET',
            data: {
                ma_dv: maDv
            },
            url: '/service/update',
            success: function (service) {
                console.log(service);
                $('#update_service_id').val(service.madv);
                $('#ten_dich_vu_update').val(service.tenDv);
                $('#don_gia_update').val(service.donGia);
                $('#tinh_theo_update').val(service.tinhTheo);
                $('#trang_thai_update').val(service.trangThai);
                
            }
        });
    });
    //Receiption
    // support get receiption id for delete
    $('.hoa_don_action a').click(function () {
        var maHd = $(this).attr('id');
        console.log("Ma hoa don: " + maHd);
        $.ajax({
            type: 'GET',
            data: {
                ma_hd: maHd
            },
            url: '/receiption/delete',
            success: function (receiption) {
                console.log(receiption);
                $('#delete_receiption_id').val(receiption.mahd);
                $('#delete_receiption_id_text').text(receiption.mahd);
            }
        });
    });
   
});
=======
        // them khach o vao table ben duoi don dat phong

        $('#them_khach_o').click(function () {
            //var tong_tien = $('#tong_tien').val();
            //var ngay_vao = $('#ngay_vao').val();
            //var vao_luc = $('#vao_luc').val();
            //var ngay_roi = $('#roi_luc').val();
            //var tien_coc = $('#tien_coc').val();
            //var phong_so = $('#phong_so').val();
            //var ghi_chu = $('#ghi_chu').val();

            console.log("click");

            var so_can_cuoc = $('#so_can_cuoc').val();
            var ho_ten = $('#ho_ten').val();
            var email = $('#email_khach').val();
            var ngay_sinh = $('#ngay_sinh').val();
            var sdt = $('#sdt').val();
            var gioi_tinh = $("input[name='gioi_tinh']:checked").val();
            var quoc_gia = $('#quoc_gia').val();

            var row =
                '<tr>' +

                `<td>${so_can_cuoc}</td>` +
                `<input type="hidden" name="so_can_cuoc_kh" value="${so_can_cuoc}"/>` +

                `<td>${ho_ten}</td>` +
                `<input type="hidden" name="ho_ten_kh" value="${ho_ten}"/>` +

                `<td>${email}</td>` +
                `<input type="hidden" name="email_kh" value="${email}"/>` +

                `<td>${ngay_sinh}</td>` +
                `<input type="hidden" name="ngay_sinh_kh" value="${ngay_sinh}"/>` +

                `<td>${sdt}</td>` +
                `<input type="hidden"  name="sdt_kh" value="${sdt}"/>` +

                `<td>${gioi_tinh}</td>` +
                `<input type="hidden"  name="gioi_tinh_kh" value="${gioi_tinh}"/>` +

                `<td>${quoc_gia}</td>` +
                `<input type="hidden"  name="quoc_gia_kh" value="${quoc_gia}"/>` +
                `
                <td class="khach_o_action">
                    <a id='${so_can_cuoc}' data-id="chinh_sua_khach_o" href="#" ><i class="fa fa-edit text-info"></i></a>
                    <br />
                    <a onClick="$(this).closest('tr').remove();" href="#"><i class="fa fa-remove text-danger"></i></a>
                </td >`+

                + '</tr > ';

            $('#ds_khach_o tbody').prepend(row);
            
        });

        // lam moi danh sach khach o

        $('#lam_moi_khach_o').click(function () {
            $('#so_can_cuoc').val('');
            $('#ho_ten').val('');
            $('#email_khach').val('');
            $('#ngay_sinh').val('dd/MM/yyyy');
            $('#sdt').val('');
            $("input[name=gioi_tinh][value=nam]").prop('checked', true);
            $('#quoc_gia').val('');
        });

        // kiem tra so can cuoc lieu co phai la khach hang cu

        $('#so_can_cuoc').keyup(function () {
            var soCanCuoc = $('#so_can_cuoc').val();
            console.log(soCanCuoc);
            $.ajax({
                type: 'GET',
                data: {
                    cmnd: soCanCuoc
                },
                url: '/customer/is_customer_before',
                success: function (kh) {
                    console.log(kh);

                    if (kh != null) {
                        $('#so_can_cuoc').val(kh.cmnd);
                        $('#ho_ten').val(kh.tenKh);
                        $('#email_khach').val(kh.email);
                        $('#ngay_sinh').val(kh.ngaySinh);
                        $('#sdt').val(kh.sdt);
                        if (kh.gioi_tinh == 1) {
                            console.log('gioi tinh cua khach hang: '+kh.gioi_tinh);
                            $('#gioiTinhNam').prop('checked', true);
                        }
                        else {
                            $('#gioiTinhNu').prop('checked', true);

                        }
                        $('#quoc_gia').val(kh.quocTich);
                    }
                }
            });
        });

        // catch ctrl + click on room

        $('.dropdown .room').click(function (e) {
            if (e.metaKey) {
                console.log("Command+Click");
                if ($(this).css('opacity') == 0.8) {
                    $(this).css('opacity', 1);
                }
                else {
                    $(this).css('opacity', 0.8);
                }
            }
        });

        // get id phong de tao dat phong

        $("a[data-id=dat_phong]").click(function () {
            // Neu chua filter ngay dat phong

            if ($('#ngay_dat_phong_filter').length == 0) {
                $('#filter_date_booking').modal('show');
            }
            else {
                $('#create_booking_modal').modal('show');
                // khai bao chuoi chua cac phong duoc dat

                var result = '';

                // khai bao mang cac phong duoc chon

                const phongs = [];

                // add phong dau tien vao danh sach phongs tuong ung voi phong duoc click chon dat phong

                var phongDuocChon = $(this).attr('id');
                phongs.push(phongDuocChon);

                // lap qua cac phong duoc chon

                $('.dropdown .room').each(function () {
                    console.log("abc");
                    if ($(this).css('opacity') == 0.8) {
                        if ($(this).attr('id') != phongDuocChon) {
                            phongs.push($(this).attr('id'));
                        }
                    }
                });

                // Gan chuoi cac phong duoc dat

                for (let i = 0; i < phongs.length; i++) {
                    if (i == phongs.length - 1) {
                        result += phongs[i];
                    }
                    else {
                        console.log(phongs[i]);
                        result += phongs[i] + ' - ';
                    }
                }

                $('#phong_so').val(result);
                sDate = $('#ngay_vao').val();
                eDate = $('#ngay_roi').val();
                $.ajax({
                    type: 'POST',
                    data: {
                        ngay_bd: sDate,
                        ngay_kt: eDate,
                        phong_so: phongs
                    },
                    url: '/room/tinh_gia_phong',
                    success: function (data) {
                        console.log(data);
                        $('#tong_tien').val(data);
                    }
                });
            }
        });
