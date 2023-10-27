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

                $('#loai_phong_update').val(roomType.loaI_PHONG);
                $('#khong_gian_update').val(roomType.khonG_GIAN);
                $('#so_giuong_update').val(roomType.sO_GIUONG);
                $('#so_nguoi_update').val(roomType.sO_NGUOI);
                $('#update_roomtype_id').val(roomType.malp);

                $('#gia_theo_gio_update').val(roomType.giA_THEO_GIO.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#gia_theo_ngay_update').val(roomType.giA_THEO_NGAY.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#gia_theo_tuan_update').val(roomType.giA_THEO_TUAN.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#gia_theo_thang_update').val(roomType.giA_THEO_THANG.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#ngay_hieu_luc_bd_update').val(roomType.ngaY_BD);
                $('#ngay_hieu_luc_kt_update').val(roomType.ngaY_KT);


                $('#qua_1h_update').val(roomType.quA1H.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#qua_2h_update').val(roomType.quA2H.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#truoc_3h_update').val(roomType.truoC3H.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#truoc_4h_update').val(roomType.truoC4H.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $('#update_price_id').val(roomType.mA_GIA);
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
                $('#don_gia_update').val(service.donGia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
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

    // lay ve so luong khach toi da cua phong

    $('#them_khach_o').click(function () {
        var isExist = 0;

        $.each($("#ds_khach_o tbody").find("tr"), function () {
            if ($(this).find("td:first").text() == $('#so_can_cuoc').val()) {
                isExist = 1;
            }
        });

        if (isExist > 0) {
            alert('Thông tin khách hàng bị trùng lắp');
        }
        else {
            var phongSo = $('#phong_so').val();
            var maximumGuest = 0;
            $.ajax({
                type: 'GET',
                async: false,
                data: {
                    phongso: phongSo
                },
                url: '/room/so_luong_khach_chua',
                success: function (data) {
                    maximumGuest = data;
                    console.log(data);
                }
            });

            var currentAmountOfGuest = $('#ds_khach_o tbody tr').length;

            if (currentAmountOfGuest == (maximumGuest + 1)) {
                alert('Số lượng khách trong phòng không thể vượt quá ' + (maximumGuest + 1) + ' !');
            }
            else {
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
            }
        }
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

            $('#vao_luc').val('14');
            $('#roi_luc').val('12');
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
                    $('#tong_tien_dp').val(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
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
                                    <td data-value="${result[i].tonG_TIEN}">${result[i].tonG_TIEN.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
                                    <td>${result[i].tieN_COC.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
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
                                    <td>${result[i].tonG_TIEN.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td >
                                    <td>${result[i].tieN_COC.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
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
            console.log("Tong tien: "+$(this).parents('tr').find('td:eq(3)').attr('data-value'));
            $(this).parents('tr').find('td:eq(4)').text(parseFloat($(this).parents('tr').find('td:eq(3)').attr('data-value') / 2).toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
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

                    // Lay gio ra he thong
                    var dt = new Date();
                    var time = dt.getHours();

                    // Gan gio vao

                    $('#vao_luc_checkin').val(time);
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
                            $('#tong_tien_checkin').val(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                            $('#tien_coc_checkin').val((data * 1 / 2).toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
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
                                    $('#tong_tien_checkin').val(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                                    $('#tien_coc_checkin').val((data * 1 / 2).toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
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

                    if (data == 'Nhận phòng thành công') {
                        $.each($("#cac_don_dat_phong tbody").find("tr"), function () {
                            if ($(this).attr('id') == ma_ctdd) {
                                $(this).find("td:last").html('Đã nhận phòng');
                                $(this).removeClass('chosen');
                                checkInSuccessToast();
                                return;
                            }
                        });
                    }
                    else {
                        checkInFailToast();
                    }
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
                        if (data == 'Nhận phòng thành công') {
                            // Cap nhat lai trang thai cho ctdp tren man hinh

                            $.each($("#cac_don_dat_phong tbody").find("tr"), function () {
                                if ($(this).attr('id') == ctdps[i]) {
                                    $(this).find("td:last").html('Đã nhận phòng');
                                    $(this).removeClass('chosen');
                                    return;
                                }
                            });
                            checkInSuccessToast();
                        }
                        else {
                            checkInFailToast();
                        }
                    }
                });
            }
        }

        // Them phieu dich vu neu co

        $.each($("#dich_vu_su_dung tbody").find("tr"), function () {
            var madv = $(this).attr('data-value');
            var so_luong = $('#' + madv + '_soluong').val();
            var don_gia = $('#' + madv + '_dongia').val();
            var thanh_tien = $('#' + madv + '_thanhtien').val();
            var mactdp = '';
            if (phongCheckIn.length == 3) {
                mactdp = ma_ctdd;
            } else {
                const ctdps = ma_ctdd.split(' - ');
                mactdp = ctdps[0];
            }

            $.ajax({
                type: 'POST',
                data: {
                    ma_dv: madv,
                    ma_ctdp: mactdp,
                    so_luong: so_luong,
                    gia: don_gia,
                    thanh_tien: thanh_tien
                },
                url: '/service_bill/create',
                success: function (data) {
                    console.log(data);
                }
            });

        });

    });

    // Them phieu dich vu khi nhan phong
    $('#them_phieu_dich_vu').click(function () {
        var dichvu = $('#ten_dichvu').find('option:selected').val();
        var soluong = $('#so_luong_dichvu').val();
        var flag = 0;
        console.log(dichvu);
        console.log(soluong);

        $.ajax({
            type: 'GET',
            data: {
                ma_dv: dichvu
            },
            url: '/service/get_service_by_id',
            success: function (data) {
                console.log(data);

                // kiem tra dich vu da nam trong bang phieu dich vu chua

                $.each($("#dich_vu_su_dung tbody").find("tr"), function () {
                    if ($(this).attr('data-value') == dichvu) {
                        console.log('Da ton tai');

                        // Cong don so luong
                        var soLuong = parseInt($(this).find('td:eq(2)').text()) + parseInt(soluong);
                        $(this).find("td:eq(2)").text(soLuong);

                        // Parse lai tu dinh dang vnd
                        var result = $(this).find("td:eq(1)").text().split(" ");
                        // Lay ve don gia 

                        var donGiaReparse = result[0].replace('.', '');
                        console.log(donGiaReparse);

                        // Tinh lai thanh tien
                        $(this).find("td:eq(3)").text((parseFloat(donGiaReparse) * parseInt($(this).find("td:eq(2)").text())));

                        // Cap nhat value lai cho cac input field hidden

                        $('#' + dichvu + '_soluong').val(soLuong);
                        $('#' + dichvu + '_thanhtien').val(parseFloat(donGiaReparse) * parseInt(soLuong));
                        flag++;
                    }
                });

                if (flag > 0) {

                }
                else {
                    var row =
                        `<tr data-value="${data.madv}">` +

                        `<td>${data.tenDv}</td>` +
                        `<input id="${data.madv}_tendv" type="hidden" name="ten_dv" value="${data.tenDv}"/>` +

                        `<td>${parseFloat(data.donGia)}</td>` +
                        `<input id="${data.madv}_dongia" type="hidden" name="don_gia_dv" value="${data.donGia}"/>` +
                        `<td>${soluong}</td>` +
                        `<input id="${data.madv}_soluong" type="hidden" name="so_luong_dv" value="${soluong}"/>` +
                        `<td>${parseFloat(data.donGia * soluong)}</td>` +
                        `<input id="${data.madv}_thanhtien" type="hidden" name="thanh_tien_dv" value="${parseFloat(data.donGia * soluong)}"/>` +
                        `
                    <td class="phieu_dich_vu_action">
                        <a onClick="$(this).closest('tr').remove();" href="#"><i class="fa fa-remove text-danger"></i></a>
                    </td >`+

                        + '</tr > ';

                    $('#dich_vu_su_dung tbody').prepend(row);
                }
            }
        });

    });

    // Check out 1 phong

    $('a[data-id=tra_phong]').click(function () {
        $('#creat_checkout').modal('show');
        var phongso = $(this).attr('id');
        var sDate = '';
        var eDate = '';
        var maDd = '';
        var ma_ctdp = '';
        var gio_vao = '';
        var gio_ra = '';
        var tong_khach_o = 0;

        var tienPhong = 0;
        var phuThu = 0;
        var tienDichVu = 0;
        var tienCoc = 0;

        console.log(phongso);
        if (phongso != null) {
            $.ajax({
                type: 'GET',
                data: {
                    phongso: phongso
                },
                url: '/receiption/find_checkout_view_by_phso',
                async: false,
                success: function (data) {
                    console.log(data);

                    ma_ctdp = data.mA_CTDP;
                    maDd = data.mA_DON_DAT;

                    $('#tenKh_hoadon').text(data.teN_KH);
                    $('#maDonDat_hoadon').text(data.mA_DON_DAT);
                    // Gan gio vao
                    gio_vao = data.giO_VAO
                    $('#gioVao_hoadon').text(data.giO_VAO);

                    // Lay gio ra he thong
                    var dt = new Date();
                    var time = dt.getHours();

                    // Gan gio ra
                    gio_ra = time;
                    $('#gioRoi_hoadon').text(time);

                    var s = data.ngaY_VAO.substring(0, 10).split('-');
                    sDate = s[2] + '/' + s[1] + '/' + s[0];

                    var x = data.ngaY_ROI.substring(0, 10).split('-');
                    eDate = x[2] + '/' + x[1] + '/' + x[0];

                    $('#phongSo_hoadon').text(phongso);

                    $('#ngayVao_hoadon').text(sDate);
                    $('#ngayRoi_hoadon').text(eDate);
                    tienCoc = data.tieN_COC;
                    $('#tienCoc_hoadon').text(tienCoc.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));

                    const date1 = new Date(data.ngaY_VAO.substring(0, 10));
                    console.log(date1);
                    const date2 = new Date(data.ngaY_ROI.substring(0, 10));
                    console.log(date2);

                    const diffTime = Math.abs(date2 - date1);
                    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

                    if (diffDays < 7) {
                        $('#tinhTheo_hoadon').text('Ngày');
                    }
                    else if (diffDays < 30) {
                        $('#tinhTheo_hoadon').text('Tuần');
                    }
                    else {
                        $('#tinhTheo_hoadon').text('Tháng');
                    }
                }
            });
            // Tim ve so luong khach o trong phong de tinh phu thu them khach neu co

            var maximumGuest = 0;
            $.ajax({
                type: 'GET',
                async: false,
                data: {
                    phongso: phongso
                },
                url: '/room/so_luong_khach_chua',
                success: function (data) {
                    maximumGuest = data;
                    console.log(data);
                }
            });

            $.ajax({
                type: 'POST',
                data: {
                    ma_ctdp: ma_ctdp
                },
                async: false,
                url: '/chi_tiet_dat_phong/tong_khach_o',
                success: function (data) {
                    console.log("Tong khach o: " + data);
                    tong_khach_o = data;
                }
            });

            $.ajax({
                type: 'POST',
                data: {
                    ngay_bd: sDate,
                    ngay_kt: eDate,
                    phong_so: phongso
                },
                async: false,
                url: '/room/tinh_gia_phong',
                success: function (data) {
                    console.log("Gia phong: " + data);
                    tienPhong = data;

                    $('#tienPhong_hoadon').text(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                }
            });

            

            $.ajax({
                type: 'POST',
                data: {
                    phongso: phongso,
                    giovao: gio_vao,
                    giora: gio_ra
                },
                async: false,
                url: '/receiption/kiem_tra_phu_thu',
                success: function (data) {
                    console.log(data.tonG_PHU_THU);
                    phuThu = data.tonG_PHU_THU;

                    if (tong_khach_o - maximumGuest > 0) {
                        data.tonG_PHU_THU += 200000;
                    }

                    $('#phuThu_hoadon').text(data.tonG_PHU_THU.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                    var lyDoPhuThu = '';

                    if (tong_khach_o - maximumGuest > 0) {
                        $('#lyDoPhuThuThemNguoi_hoadon').text('*Phụ thu thêm một người');
                    }

                    if (14 - parseInt(gio_vao) > 3) {
                        lyDoPhuThu += '*Phụ thu do check in sớm 4 tiếng -';
                    } else if (14 - parseInt(gio_vao) > 2) {
                        lyDoPhuThu += '*Phụ thu do check in sớm 3 tiếng -';
                    }

                    if (parseInt(gio_ra) - 12 > 1) {
                        lyDoPhuThu += '* Phụ thu check out trễ 2 tiếng ';
                    } else if (parseInt(gio_ra) - 12 > 0) {
                        lyDoPhuThu += '* Phụ thu check out trễ 1 tiếng ';
                    }

                    $('#lyDoPhuThu_hoadon').text(lyDoPhuThu)
                }
            });

            $.ajax({
                type: 'POST',
                data: {
                    ngay_bd: sDate,
                    ngay_kt: eDate,
                    phong_so: phongso
                },
                async: false,
                url: '/room/tinh_gia_phong',
                success: function (data) {
                    console.log("Gia phong: " + data);
                    tienPhong = data;
                    $('#tienPhong_hoadon').text(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                }
            });

            $.ajax({
                type: 'POST',
                data: {
                    ma_ctdp: ma_ctdp
                },
                async: false,
                url: '/receiption/tim_phieu_dich_vu_by_mactdp',
                success: function (data) {
                    console.log(data);
                    var rows = '';
                    if (data.length > 0) {
                        for (let i = 0; i < data.length; i++) {
                            rows += '<tr>' + `<td>${data[i].teN_DICH_VU}</td>` +
                                `<td>${data[i].doN_GIA.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>` +
                                `<td>${data[i].sO_LUONG}</td>` +
                                `<td><b>${data[i].thanH_TIEN.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</b></td>` + '</tr > ';
                        }
                        $('#dich_vu_su_dung_hoadon tbody').html(rows);
                    }
                    else {
                        $('#dich_vu_su_dung_hoadon tbody').html('');
                    }
                }
            });

            $.ajax({
                type: 'POST',
                data: {
                    ma_ctdp: ma_ctdp
                },
                async: false,
                url: '/receiption/tinh_tong_tien_phieu_dich_vu_by_mactdp',
                success: function (data) {
                    console.log(data);
                    tienDichVu = data;
                    $('#tienDichVu_hoadon').text(data.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                }
            });

            var tongTien = 0;
            console.log("PP: "+tienPhong);
            console.log("PPP: "+ parseFloat(phuThu));
            console.log("PPPP: " + tienDichVu);
            tongTien = tienPhong + phuThu + tienDichVu - tienCoc;
            console.log(tongTien);

            $('#thanhToan_hoadon').text(tongTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
            // Gan value cho cac hidden input for form submit

            $('#ma_don_dat_hoadon').val(maDd);
            $('#tong_tien_hoadon').val(tongTien);
            $('#phu_thu_hoadon').val(phuThu);
            $('#phong_so_hoadon').val(phongso);
            $('#ma_ctdp_hoadon').val(ma_ctdp);
            $('#gio_ra_hoadon').val(gio_ra);
        }
    });

});
