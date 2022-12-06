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

    $('#create_booking').click(function () {
        showSuccessToast();
        console.log("Hello");
    });

    //$('.dropdown .room').click(function () {
    //    var roomCheckIn = $(this).attr('id');
    //    console.log(roomCheckIn);
    //    $('#roomCheck').val(roomCheckIn);
    //});

    // Them trang thai cho phong

    $('.dropdown .room').each(function () {
        console.log("duyet phong");
        var phongSo = $(this).attr('id');
        if ($(this).attr('data-value') == 'Khách đang ở') {
            $(this).addClass('staying_room');

            //$.ajax({
            //    type: 'GET',
            //    url: '/chi_tiet_dat_phong/tim_tat_ca_chitietdondat',
            //    success: function (result) {
            //        console.log(result);
            //        for (let i = 0; i < result.length; i++) {
            //            if (phongSo == result[i].phonG_SO && result[i].tranG_THAI == 'Đã nhận phòng') {
            //                console.log("hop le");
            //                $('.dropdown .room').filter($(this).attr('id') == phongSo).append(`<div class="stayInfo">${result[i].checK_IN.substring(0, 10)} - ${result[i].checK_OUT.substring(0, 10)} </div>`);
            //            }
            //        }
            //    }
            //});
        }
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
        console.log("Tang thu: " + floorNumber);
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

    $('a[data-id=xoa_loai_phong]').click(function () {
        var loaiPhong = $(this).attr('id');
        console.log("Loai phong: " + loaiPhong);

        var maLp = $(this).attr('data-value');
        console.log("Ma loai phong: " + maLp);

        $('#delete_room_type').text(loaiPhong);
        $('#delete_room_type_id').val(maLp);
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
        $('#delete_receiption_id').val(maHd);
        $('#delete_receiption_id_text').text(maHd);
                
    });


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
        if (soCanCuoc.length == 12) {
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
                        $('#ho_ten').val(kh.teN_KH);
                        $('#email_khach').val(kh.email);
                        $('#ngay_sinh').val(kh.dob);
                        $('#sdt').val(kh.sdt);
                        if (kh.gender == 1) {
                            console.log('gioi tinh cua khach hang: ' + kh.gender);
                            $("input[name=gioi_tinh][value=nam]").prop('checked', true);
                        }
                        else {
                            $("input[name=gioi_tinh][value=nu]").prop('checked', true);

                        }
                        $('#quoc_gia').val(kh.quoC_TICH);
                    }
                }
            });
        }
    });

    // catch ctrl + click on room

    $('.dropdown .room').click(function (e) {
        if (e.metaKey) {
            console.log("Command+Click");
            if ($(this).hasClass('chosen_room')) {
                $(this).removeClass('chosen_room');
            }
            else {
                $(this).addClass('chosen_room');
            }
        }
        else {
            $('.dropdown .room').removeClass('chosen_room');
            $(this).addClass('chosen_room');
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
                if ($(this).hasClass('chosen_room')) {
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

            // Tinh tong tien

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

    // Ajax hien thi danh sach cac don dat phong trong bang check in

    $("a[data-id=ds_don_dat]").click(function () {
        console.log("danh sach don dat");
        var roomId = $(this).attr('id');
        $.ajax({
            type: 'GET',
            data: {
                ma_phong: roomId
            },
            url: '/chi_tiet_dat_phong/tim_theo_maphong',
            success: function (result) {
                console.log(result);
                var data = '';
                for (let i = 0; i < result.length; i++) {
                    if (result[i].tranG_THAI === 'Đã huỷ') {

                    } else {
                        data +=
                            `<tr id="${result[i].cT_DON_DAT}" data-value="${result[i].mA_DON_DAT}">
                                    <td><a id="${result[i].cT_DON_DAT}" href="#"><i class="ti-share"></i></a></td>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td>${result[i].checK_IN}</td>
                                    <td>${result[i].checK_OUT}</td>
                                    <td>${result[i].phonG_SO}</td>
                                    <td>${result[i].loaI_PHONG}</td>
                                    <td>${result[i].tranG_THAI}</td>
                                </tr>`;
                    }
                }
                $('#cac_don_dat_phong tbody').html(data);
            }
        });
    });

    // Tim tat ca cac chi tiet don dat theo ma don dat

    $('#tim_theo_madondat').keyup(function () {
        var maDonDat = $(this).val();
        console.log(maDonDat);
        if (maDonDat.length == 5) {
            $.ajax({
                type: 'POST',
                data: {
                    ma_don_dat: maDonDat
                },
                url: '/chi_tiet_dat_phong/tim_theo_madondat',
                success: function (result) {
                    console.log(result);
                    var data = '';
                    for (let i = 0; i < result.length; i++) {
                        if (result[i].tranG_THAI === 'Đã huỷ') {

                        } else {
                            data +=
                                `<tr id="${result[i].cT_DON_DAT}" data-value="${result[i].mA_DON_DAT}">
                                    <td><a id="${result[i].cT_DON_DAT}" href="#"><i class="ti-share"></i></a></td>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td>${result[i].checK_IN}</td>
                                    <td>${result[i].checK_OUT}</td>
                                    <td>${result[i].phonG_SO}</td>
                                    <td>${result[i].loaI_PHONG}</td>
                                    <td>${result[i].tranG_THAI}</td>
                                </tr>`;
                        }
                    }
                    $('#cac_don_dat_phong tbody').html(data);
                }
            });
        }
    });

    // tim tat cac cac chi tiet don dat theo ngay check in

    $(".datepicker").datepicker({
        onSelect: function (dateText) {
            display("Selected date: " + dateText + ", Current Selected Value= " + this.value);
            $(this).change();
        }
    }).on("change", function () {
        var date = $('#tim_theo_checkin').val();
        $.ajax({
            type: 'GET',
            data: {
                check_in: date
            },
            url: '/chi_tiet_dat_phong/tim_theo_checkin',
            success: function (result) {
                console.log(result);
                if (result != null) {
                    var data = '';
                    for (let i = 0; i < result.length; i++) {
                        if (result[i].tranG_THAI === 'Đã huỷ') {

                        } else {
                            data +=
                                `<tr id="${result[i].cT_DON_DAT}" data-value="${result[i].mA_DON_DAT}">
                                    <td><a id="${result[i].cT_DON_DAT}" href="#"><i class="ti-share"></i></a></td>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td>${result[i].checK_IN}</td>
                                    <td>${result[i].checK_OUT}</td>
                                    <td>${result[i].phonG_SO}</td>
                                    <td>${result[i].loaI_PHONG}</td>
                                    <td>${result[i].tranG_THAI}</td>
                                </tr>`;
                        }
                    }
                    $('#cac_don_dat_phong tbody').html(data);
                }
            }
        });
    });

    // Tim tat ca cac don dat phong chi tiet

    $('#tim_tat_ca_ctdp').click(function () {
        $.ajax({
            type: 'GET',
            url: '/chi_tiet_dat_phong/tim_tat_ca_chitietdondat',
            success: function (result) {
                console.log(result);
                var data = '';
                for (let i = 0; i < result.length; i++) {
                    if (result[i].tranG_THAI === 'Đã huỷ') {

                    } else {
                        data +=
                            `<tr id="${result[i].cT_DON_DAT}" data-value="${result[i].mA_DON_DAT}">
                                    <td><a id="${result[i].cT_DON_DAT}" href="#"><i class="ti-share"></i></a></td>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td>${result[i].checK_IN}</td>
                                    <td>${result[i].checK_OUT}</td>
                                    <td>${result[i].phonG_SO}</td>
                                    <td>${result[i].loaI_PHONG}</td>
                                    <td>${result[i].tranG_THAI}</td>
                                </tr>`;
                    }
                }
                $('#cac_don_dat_phong tbody').html(data);
            }
        });
    });

    // Click chon chi tiet don dat va check in

    $('#cac_don_dat_phong').on('click', 'tbody tr', function (e) {
        if (e.metaKey) {
            if ($(this).hasClass('chosen')) {
                $(this).removeClass('chosen');
            }
            else {
                // Kiem tra trung don dat

                $(this).addClass('chosen');
                const ma_don_dat_ids = [];

                $('tbody .chosen').each(function () {
                    ma_don_dat_ids.push($(this).attr('data-value'));
                });

                if (ma_don_dat_ids.length > 0) {
                    let flag = 0;
                    for (let i = 0; i < ma_don_dat_ids.length; i++) {
                        for (let j = 0; j < ma_don_dat_ids.length; j++) {
                            if (!(ma_don_dat_ids[i] === ma_don_dat_ids[j])) {
                                flag++;
                            }
                        }
                    }
                    if (flag > 0) {
                        alert("Không cùng đơn đặt phòng. Bạn chỉ có thể check in cho các phòng có cùng đơn đặt");
                        $(this).removeClass('chosen');
                    }
                }
            }
        }
        else {
            $(this).addClass('chosen').siblings().removeClass('chosen');
        }
    });

    function isKhachHang(soCanCuoc) {
        $.ajax({
            type: 'GET',
            data: {
                cmnd: soCanCuoc
            },
            url: '/customer/is_customer_before',
            success: function (kh) {
                console.log(kh);

                if (kh != null) {
                    $('#ho_ten_check_in').val(kh.teN_KH);
                    $('#email_khach_check_in').val(kh.email);
                    $('#ngay_sinh_check_in').val(kh.dob);
                    $('#sdt_check_in').val(kh.sdt);
                    if (kh.gender == 1) {
                        console.log('gioi tinh cua khach hang: ' + kh.gender);
                        $("input[name=gioi_tinh][value=nam]").prop('checked', true);
                    }
                    else {
                        $("input[name=gioi_tinh][value=nu]").prop('checked', true);

                    }
                    $('#quoc_gia_check_in').val(kh.quoC_TICH);
                }
            }
        });
    }

    // Tim tat ca cac don dat phong

    $('#show_ds_dat_phong').click(function () {
        $.ajax({
            type: 'GET',
            url: '/booking/findall',
            success: function (result) {
                console.log(result);
                if (result != null) {
                    var data = '';
                    for (let i = 0; i < result.length; i++) {
                        if (result[i].tranG_THAI === 'Đợi chuyển cọc') {
                            data +=
                                `<tr>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td class="text-danger">${result[i].tranG_THAI}   <i id="cap_nhat_tien_coc" data-value="${result[i].mA_DON_DAT}" class="fa fa-credit-card text-info"></i></td>
                                    <td>${result[i].tonG_TIEN}</td >
                                    <td>
                                        <a class="text-info" id="${result[i].mA_DON_DAT}" ><i class="ti-check-box"></i> Xem chi tiết</a>
                                    </td>
                                </tr>`;
                        }
                        else if (result[i].tranG_THAI === 'Đã huỷ') {

                        }
                        else {
                            data +=
                                `<tr>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td class="text-success">${result[i].tranG_THAI}</td>
                                    <td>${result[i].tonG_TIEN}</td >
                                    <td>
                                        <a class="text-info" id="${result[i].mA_DON_DAT}" ><i class="ti-check-box"></i> Xem chi tiết</a>
                                    </td>
                                </tr>`;
                        }
                    }
                    $('#danh_sach_don_dat tbody').html(data);
                }
            }
        });
    });

    $('#danh_sach_don_dat').on('click', 'tbody tr td #cap_nhat_tien_coc', function (e) {
        if (confirm("Đã nhận 50% tiền cọc !")) {
            var maDonDat = $(this).attr('data-value');
            $.ajax({
                type: 'POST',
                data: {
                    ma_don_dat: maDonDat
                },
                url: '/booking/capNhatTienCoc',
                success: function (result) {
                    if (result == 'success') {
                        updateDepositSuccessToast();
                    }
                    else {
                        updateDepositFailToast();
                        return;
                    }
                }
            });
            $(this).closest('td').removeClass('text-danger').addClass('text-success').html('Đã chuyển cọc');
        } else {

        }
    });

    $('#danh_sach_don_dat').on('click', 'tbody tr td a', function (e) {
        var maDonDat = $(this).attr('id');
        console.log(maDonDat);
        if (maDonDat.length == 5) {
            $.ajax({
                type: 'POST',
                data: {
                    ma_don_dat: maDonDat
                },
                url: '/chi_tiet_dat_phong/tim_theo_madondat',
                success: function (result) {
                    console.log(result);
                    var data = '';
                    for (let i = 0; i < result.length; i++) {
                        if (result[i].tranG_THAI === 'Đã huỷ') {

                        } else {
                            data +=
                                `<tr id="${result[i].cT_DON_DAT}" data-value="${result[i].mA_DON_DAT}">
                                    <td><a id="${result[i].cT_DON_DAT}" href="#"><i class="ti-share"></i></a></td>
                                    <td>${result[i].mA_DON_DAT}</td>
                                    <td>${result[i].teN_KH}</td>
                                    <td>${result[i].checK_IN}</td>
                                    <td>${result[i].checK_OUT}</td>
                                    <td>${result[i].phonG_SO}</td>
                                    <td>${result[i].loaI_PHONG}</td>
                                    <td>${result[i].tranG_THAI}</td>
                                </tr>`;
                        }
                    }
                    $('#cac_don_dat_phong tbody').html(data);
                }
            });
        }
    });

    // Kiem tra xem 2 don dat phong duoc chon co cung ma don dat hay ko

    $('#nhan_phong_tu_danh_sach_dat').click(function () {
        console.log('Nhan phong button is clicked');
        // Format date ngay nhan phong = ngay he thong

        const chi_tiet_don_dat_ids = [];

        // Nhan ve danh sach phong

        let phongs = [];

        // Lay ve ngay cua he thong

        var today = new Date();

        var day = String(today.getDate()).padStart(2, '0');
        var month = String(today.getMonth() + 1).padStart(2, '0');
        var year = String(today.getFullYear());

        var sDate = day + '/' + month + '/' + year;
        var eDate;

        $('#cac_don_dat_phong tbody .chosen').each(function () {
            chi_tiet_don_dat_ids.push($(this).attr('id'));
        });

        console.log(chi_tiet_don_dat_ids);

        // Neu nhan 1 phong
        // Nhan Phong Khach Le dat truoc

        if (chi_tiet_don_dat_ids.length == 1) {
            phongs = [];
            // Hien thi thong tin check in 1 phong
            $('#create_check_in').modal('show');
            var ma_ctdd = chi_tiet_don_dat_ids[0];

            $.ajax({
                type: 'POST',
                data: {
                    ma_ct_dondat: ma_ctdd
                },
                url: '/chi_tiet_dat_phong/tim_theo_ma_ct_dondat',
                success: function (result) {
                    phongs.push(result.phonG_SO);

                    eDate = result.checK_OUT;
                    // format end date to dd/MM/yyyy

                    var s = eDate.substring(0, 10).split('-');
                    eDate = s[2] + '/' + s[1] + '/' + s[0];

                    $('#ngay_roi_checkin').val(eDate);
                    $('#ngay_vao_checkin').val(sDate);
                    $('#roi_luc_checkin').val(result.giO_RA);
                    $('#phong_so_checkin').val(result.phonG_SO);
                    $('#ghi_chu_checkin').val(result.ghI_CHU);
                    $('#loai_phong_dang_ky').val(result.loaI_PHONG);
                    $('#so_can_cuoc_check_in').val(result.sO_CAN_CUOC);

                    // Truyen ma chi tiet don dat phuc vu cho viec nhan 1 phong

                    $('#ma_ctdp_checkin').val(ma_ctdd);

                    // Hien thi thong tin khach hang dat truoc thong qua cmnd cua khach

                    if ($('#so_can_cuoc_check_in').val() != null) {
                        isKhachHang(result.sO_CAN_CUOC);
                    }

                    // Tinh tong tien cho phong thuc hien check in

                    $.ajax({
                        type: 'POST',
                        data: {
                            ngay_bd: sDate,
                            ngay_kt: eDate,
                            phong_so: phongs
                        },
                        url: '/room/tinh_gia_phong',
                        success: function (data) {
                            $('#tong_tien_checkin').val(data);
                            $('#tien_coc_checkin').val(data * 1 / 2);
                        }
                    });
                }
            });
        }

        // Neu nhan 1 phong tro len
        // Nhan Phong Khach Doan dat truoc

        else if (chi_tiet_don_dat_ids.length > 1) {
            phongs = [];
            $('#create_check_in').modal('show');
            // Truyen ma chi tiet don dat phuc vu cho viec nhan nhieu hon 1 phong

            var maChiTietDatPhong = '';

            for (let i = 0; i < chi_tiet_don_dat_ids.length; i++) {
                if (i == chi_tiet_don_dat_ids.length - 1) {
                    maChiTietDatPhong += chi_tiet_don_dat_ids[i];
                }
                else {
                    maChiTietDatPhong += chi_tiet_don_dat_ids[i] + ' - ';
                }
            }

            $('#ma_ctdp_checkin').val(maChiTietDatPhong);


            // Lap qua cac ct don dat hien thi thong tin dat phong cua khach doan

            for (let i = 0; i < chi_tiet_don_dat_ids.length; i++) {
                var ma_ctdd = chi_tiet_don_dat_ids[i];
                $.ajax({
                    type: 'POST',
                    data: {
                        ma_ct_dondat: ma_ctdd
                    },
                    url: '/chi_tiet_dat_phong/tim_theo_ma_ct_dondat',
                    success: function (result) {
                        phongs.push(result.phonG_SO);

                        eDate = result.checK_OUT;
                        // format end date to dd/MM/yyyy

                        var s = eDate.substring(0, 10).split('-');
                        eDate = s[2] + '/' + s[1] + '/' + s[0];


                        $('#ngay_roi_checkin').val(eDate);
                        $('#ngay_vao_checkin').val(sDate);
                        $('#roi_luc_checkin').val(result.giO_RA);

                        //$('#phong_so_checkin').val(listPhongs);

                        $('#ghi_chu_checkin').val(result.ghI_CHU);

                        $('#so_can_cuoc_check_in').val(result.sO_CAN_CUOC);

                        // Hien thi thong tin khach hang dat truoc thong qua cmnd cua khach

                        if ($('#so_can_cuoc_check_in').val() != null) {
                            isKhachHang(result.sO_CAN_CUOC);
                        }

                        // Tinh tong tien cho phong thuc hien check in


                        if (i == chi_tiet_don_dat_ids.length - 1) {
                            $.ajax({
                                type: 'POST',
                                data: {
                                    ngay_bd: sDate,
                                    ngay_kt: eDate,
                                    phong_so: phongs
                                },
                                url: '/room/tinh_gia_phong',
                                success: function (data) {
                                    $('#tong_tien_checkin').val(data);
                                    $('#tien_coc_checkin').val(data * 1 / 2);
                                    assignRoomCheckIn(phongs);
                                }
                            });
                        }

                    }
                });
            }
        }
        else {
            alert('Chọn vào đơn đặt cần thực hiện nhận phòng hoặc nhận phòng trực tiếp từ phòng !');
        }

    });

    // Nhan Phong Khach Doan dat truoc

    // Gan cac phong kh thuc hien nhan phong cho khach doan

    function assignRoomCheckIn(phongs) {
        var phongsCheckIn = '';
        for (let i = 0; i < phongs.length; i++) {
            if (i == phongs.length - 1) {
                phongsCheckIn += phongs[i];
            }
            else {
                phongsCheckIn += phongs[i] + ' - ';
            }
        }
        $('#phong_so_checkin').val(phongsCheckIn);
    }

    $('#check_in_for_customer').click(function () {
        var phongCheckIn = $('#phong_so_checkin').val();
        var ma_ctdd = $('#ma_ctdp_checkin').val();

        // Neu check in 1 phong

        if (phongCheckIn.length == 3) {
            $.ajax({
                type: 'POST',
                data: {
                    ma_ct_dondat: ma_ctdd
                },
                url: '/chi_tiet_dat_phong/nhan_phong_theo_ma_ct_dondat',
                success: function (data) {
                    console.log(data);

                    // Cap nhat lai trang thai cho ctdp tren man hinh

                    $.each($("#cac_don_dat_phong tbody").find("tr"), function () {
                        if ($(this).attr('id') == ma_ctdd) {
                            $(this).find("td:last").html('<i><b>Đã nhận phòng</b></i>  <i class="fa fa-check text-success"></i>');
                            $(this).removeClass('chosen');
                            checkInSuccessToast();
                            return;
                        }
                    });
                }
            });

        }

        // Neu check in nhieu hon 1 phong

        if (phongCheckIn.length > 3) {
            // split cac phong ra theo " - "

            const ps = $('#phong_so_checkin').val().split(' - ');
            const ctdps = ma_ctdd.split(' - ');

            for (let i = 0; i < ctdps.length; i++) {
                $.ajax({
                    type: 'POST',
                    data: {
                        ma_ct_dondat: ctdps[i]
                    },
                    url: '/chi_tiet_dat_phong/nhan_phong_theo_ma_ct_dondat',
                    success: function (data) {
                        console.log(data);

                        // Cap nhat lai trang thai cho ctdp tren man hinh

                        $.each($("#cac_don_dat_phong tbody").find("tr"), function () {
                            if ($(this).attr('id') == ctdps[i]) {
                                $(this).find("td:last").html('<i><b>Đã nhận phòng</b></i>  <i class="fa fa-check text-success"></i>');
                                $(this).removeClass('chosen');
                                return;
                            }
                        });
                    }
                });
            }
            checkInSuccessToast();
        }
    });

});
