using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_DiyetProjesi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gunler",
                columns: table => new
                {
                    GunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BugununTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gunler", x => x.GunID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HedefKilo = table.Column<double>(type: "float", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boy = table.Column<int>(type: "int", nullable: false),
                    GuncelKilo = table.Column<double>(type: "float", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kalori = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoymusYag = table.Column<double>(type: "float", nullable: false),
                    TransYag = table.Column<double>(type: "float", nullable: false),
                    TekliDoymamisYag = table.Column<double>(type: "float", nullable: false),
                    CokluDoymamisYag = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Karbonhidrat = table.Column<double>(type: "float", nullable: false),
                    Seker = table.Column<double>(type: "float", nullable: false),
                    Sodyum = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Potasyum = table.Column<double>(type: "float", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunID);
                });

            migrationBuilder.CreateTable(
                name: "GunKullanici",
                columns: table => new
                {
                    GunlerGunID = table.Column<int>(type: "int", nullable: false),
                    KullanicilarUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunKullanici", x => new { x.GunlerGunID, x.KullanicilarUserID });
                    table.ForeignKey(
                        name: "FK_GunKullanici_Gunler_GunlerGunID",
                        column: x => x.GunlerGunID,
                        principalTable: "Gunler",
                        principalColumn: "GunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GunKullanici_Kullanicilar_KullanicilarUserID",
                        column: x => x.KullanicilarUserID,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GunUrunDetaylari",
                columns: table => new
                {
                    GunID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UrunGramaj = table.Column<double>(type: "float", nullable: false),
                    AlinmisKalori = table.Column<double>(type: "float", nullable: false),
                    GununZamani = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunUrunDetaylari", x => new { x.UrunID, x.GunID, x.UserID });
                    table.ForeignKey(
                        name: "FK_GunUrunDetaylari_Gunler_GunID",
                        column: x => x.GunID,
                        principalTable: "Gunler",
                        principalColumn: "GunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GunUrunDetaylari_Kullanicilar_UserID",
                        column: x => x.UserID,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GunUrunDetaylari_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GunKullanici_KullanicilarUserID",
                table: "GunKullanici",
                column: "KullanicilarUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GunUrunDetaylari_GunID",
                table: "GunUrunDetaylari",
                column: "GunID");

            migrationBuilder.CreateIndex(
                name: "IX_GunUrunDetaylari_UserID",
                table: "GunUrunDetaylari",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GunKullanici");

            migrationBuilder.DropTable(
                name: "GunUrunDetaylari");

            migrationBuilder.DropTable(
                name: "Gunler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
