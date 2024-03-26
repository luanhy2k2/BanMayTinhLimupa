using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kho", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "Loaisp",
                columns: table => new
                {
                    loai_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loai_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loaisp__25B10ED8F4FCD793", x => x.loai_id);
                });

            migrationBuilder.CreateTable(
                name: "Nhasx",
                columns: table => new
                {
                    nsx_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nsx_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
                    sdt = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nhasx__298823BF3D295D5C", x => x.nsx_id);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    MaSlide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slide = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.MaSlide);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonNhap",
                columns: table => new
                {
                    SoHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "date", nullable: true),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToTal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonNhap", x => x.SoHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDonNhap_AspNetUsers",
                        column: x => x.MaNguoiDung,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(type: "date", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiGiaoHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToTal = table.Column<int>(type: "int", nullable: true),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK__DonHang__MaKhach__778AC167",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonBan",
                columns: table => new
                {
                    SoHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBan = table.Column<DateTime>(type: "date", nullable: true),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true),
                    ToTal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonBan", x => x.SoHoaDon);
                    table.ForeignKey(
                        name: "FK__HoaDonBan__MaKha__2739D489",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang");
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    sanp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanp_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    loai_id = table.Column<int>(type: "int", nullable: false),
                    nsx_id = table.Column<int>(type: "int", nullable: false),
                    ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    display = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    battery = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    card = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tomtat = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValueSql: "((0))"),
                    namsx = table.Column<DateTime>(type: "datetime", nullable: true),
                    image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sanpham__FBCD4D6E7BD38EE4", x => x.sanp_id);
                    table.ForeignKey(
                        name: "FK__Sanpham__loai_id__7E37BEF6",
                        column: x => x.loai_id,
                        principalTable: "Loaisp",
                        principalColumn: "loai_id");
                    table.ForeignKey(
                        name: "FK__Sanpham__nsx_id__7F2BE32F",
                        column: x => x.nsx_id,
                        principalTable: "Nhasx",
                        principalColumn: "nsx_id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietAnh",
                columns: table => new
                {
                    MaAnhChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietAnh", x => x.MaAnhChiTiet);
                    table.ForeignKey(
                        name: "FK__ChiTietAn__sanp___6EF57B66",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaChiTietDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonHang = table.Column<int>(type: "int", nullable: true),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaMua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.MaChiTietDonHang);
                    table.ForeignKey(
                        name: "FK__ChiTietDo__MaDon__4F47C5E3",
                        column: x => x.MaDonHang,
                        principalTable: "DonHang",
                        principalColumn: "MaDonHang");
                    table.ForeignKey(
                        name: "FK__ChiTietDo__sanp___70DDC3D8",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDonBan",
                columns: table => new
                {
                    MaChiTietHoaDonBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHoaDon = table.Column<int>(type: "int", nullable: true),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaBan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDonBan", x => x.MaChiTietHoaDonBan);
                    table.ForeignKey(
                        name: "FK__ChiTietHo__sanp___71D1E811",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                    table.ForeignKey(
                        name: "FK__ChiTietHo__SoHoa__72C60C4A",
                        column: x => x.SoHoaDon,
                        principalTable: "HoaDonBan",
                        principalColumn: "SoHoaDon");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDonNhap",
                columns: table => new
                {
                    MaChiTietHoaDonNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHoaDon = table.Column<int>(type: "int", nullable: true),
                    nsx_id = table.Column<int>(type: "int", nullable: true),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDonNhap", x => x.MaChiTietHoaDonNhap);
                    table.ForeignKey(
                        name: "FK__ChiTietHo__sanp___73BA3083",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonNhap_HoaDonNhap",
                        column: x => x.SoHoaDon,
                        principalTable: "HoaDonNhap",
                        principalColumn: "SoHoaDon");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonNhap_Nhasx",
                        column: x => x.nsx_id,
                        principalTable: "Nhasx",
                        principalColumn: "nsx_id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKho",
                columns: table => new
                {
                    MaChiTietKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKho", x => x.MaChiTietKho);
                    table.ForeignKey(
                        name: "FK__ChiTietKh__MaKho__75A278F5",
                        column: x => x.MaKho,
                        principalTable: "Kho",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK__ChiTietKh__sanp___76969D2E",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                });

            migrationBuilder.CreateTable(
                name: "GiaCa",
                columns: table => new
                {
                    MaSo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    Gia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaCa", x => x.MaSo);
                    table.ForeignKey(
                        name: "FK__GiaCa__sanp_id__787EE5A0",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                });

            migrationBuilder.CreateTable(
                name: "productComment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanp_id = table.Column<int>(type: "int", nullable: true),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    noiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productComment", x => x.id);
                    table.ForeignKey(
                        name: "FK__productCo__sanp___7D439ABD",
                        column: x => x.sanp_id,
                        principalTable: "Sanpham",
                        principalColumn: "sanp_id");
                    table.ForeignKey(
                        name: "FK_productComment_AspNetUsers",
                        column: x => x.MaNguoiDung,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietAnh_sanp_id",
                table: "ChiTietAnh",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDonHang",
                table: "ChiTietDonHang",
                column: "MaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_sanp_id",
                table: "ChiTietDonHang",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonBan_sanp_id",
                table: "ChiTietHoaDonBan",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonBan_SoHoaDon",
                table: "ChiTietHoaDonBan",
                column: "SoHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonNhap_nsx_id",
                table: "ChiTietHoaDonNhap",
                column: "nsx_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonNhap_sanp_id",
                table: "ChiTietHoaDonNhap",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonNhap_SoHoaDon",
                table: "ChiTietHoaDonNhap",
                column: "SoHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKho_MaKho",
                table: "ChiTietKho",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKho_sanp_id",
                table: "ChiTietKho",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaKhachHang",
                table: "DonHang",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_GiaCa_sanp_id",
                table: "GiaCa",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBan_MaKhachHang",
                table: "HoaDonBan",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonNhap_MaNguoiDung",
                table: "HoaDonNhap",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_productComment_MaNguoiDung",
                table: "productComment",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_productComment_sanp_id",
                table: "productComment",
                column: "sanp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserId",
                table: "Room",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_loai_id",
                table: "Sanpham",
                column: "loai_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_nsx_id",
                table: "Sanpham",
                column: "nsx_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietAnh");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDonBan");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDonNhap");

            migrationBuilder.DropTable(
                name: "ChiTietKho");

            migrationBuilder.DropTable(
                name: "GiaCa");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "productComment");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "HoaDonBan");

            migrationBuilder.DropTable(
                name: "HoaDonNhap");

            migrationBuilder.DropTable(
                name: "Kho");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Loaisp");

            migrationBuilder.DropTable(
                name: "Nhasx");
        }
    }
}
