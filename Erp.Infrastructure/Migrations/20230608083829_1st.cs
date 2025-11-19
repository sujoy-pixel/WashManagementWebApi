using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erp.Infrastructure.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIONS_LIST",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACTION_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIONS_LIST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    AddressFirst = table.Column<string>(nullable: true),
                    AddressSecond = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    HeadOfficeId = table.Column<int>(nullable: false),
                    BranchOfficeId = table.Column<int>(nullable: false),
                    TokenNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BARCODE_GEN",
                columns: table => new
                {
                    BARCODE_GEN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE_ID = table.Column<int>(nullable: false),
                    FABRIC_DETAILS_ID = table.Column<int>(nullable: false),
                    SIZE_ID = table.Column<int>(nullable: false),
                    EXPOTER_ID = table.Column<int>(nullable: false),
                    IMPORTER_ID = table.Column<int>(nullable: false),
                    BARCODE_NO = table.Column<string>(nullable: true),
                    COUNTRY_OF_ORIGIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARCODE_GEN", x => x.BARCODE_GEN_ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_BASIC",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<string>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    EMPLOYEE_NAME = table.Column<string>(nullable: true),
                    EMPLOYEE_NAME_BANGLA = table.Column<string>(nullable: true),
                    FATHER_NAME = table.Column<string>(nullable: true),
                    MOTHER_NAME = table.Column<string>(nullable: true),
                    DATE_OF_BIRTH = table.Column<DateTime>(nullable: true),
                    CARD_NO = table.Column<string>(nullable: true),
                    PUNCH_CODE = table.Column<string>(nullable: true),
                    GENDER_ID = table.Column<int>(nullable: false),
                    BLOOD_GROUP_ID = table.Column<int>(nullable: false),
                    MARITAL_STATUS_ID = table.Column<int>(nullable: false),
                    SPOUSE_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_BASIC", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "FABRIC_DETAILS",
                columns: table => new
                {
                    FABRIC_DETAIL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FABRIC_DETAIL_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FABRIC_DETAILS", x => x.FABRIC_DETAIL_ID);
                });

            migrationBuilder.CreateTable(
                name: "FABRIC_LIBRARY_MAIN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    ST_CODE = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    FABRIC_BASIC_NAME_ID = table.Column<int>(nullable: false),
                    FABRIC_TYPE_ID = table.Column<int>(nullable: false),
                    COMPOSITION = table.Column<string>(nullable: true),
                    CONSTRUCTION = table.Column<string>(nullable: true),
                    COUNT = table.Column<string>(nullable: true),
                    CUTTABLE_WIDTH = table.Column<string>(nullable: true),
                    WEIGHT = table.Column<double>(nullable: false),
                    UNIT_TYPE_ID = table.Column<int>(nullable: false),
                    DESIGN = table.Column<string>(nullable: true),
                    WEAVING = table.Column<string>(nullable: true),
                    DYEING = table.Column<string>(nullable: true),
                    FINISHING = table.Column<string>(nullable: true),
                    SUP_BYR_MODEL_CODE = table.Column<string>(nullable: true),
                    SUP_BYR_DESCRIPTION = table.Column<string>(nullable: true),
                    SUPPLIER_ID = table.Column<int>(nullable: false),
                    ORIGIN_ID = table.Column<int>(nullable: false),
                    FABRIC_MILL_ID = table.Column<int>(nullable: false),
                    UNIT_PRICE = table.Column<double>(nullable: false),
                    CURRENCY_ID = table.Column<int>(nullable: false),
                    UNIT_ID = table.Column<int>(nullable: false),
                    MODEL_ID = table.Column<int>(nullable: false),
                    PAYMENT_MODE_ID = table.Column<int>(nullable: false),
                    PRICE_VALIDITY_DATE = table.Column<DateTime>(nullable: false),
                    MOQ = table.Column<double>(nullable: false),
                    MCQ = table.Column<double>(nullable: false),
                    MOQ_UP_CHARGE = table.Column<double>(nullable: false),
                    MCQ_UP_CHARGE = table.Column<double>(nullable: false),
                    COLOR = table.Column<string>(nullable: true),
                    COLOR_CODE = table.Column<string>(nullable: true),
                    COLOR_DESCRIPTION = table.Column<string>(nullable: true),
                    NOMINATION_STATUS = table.Column<string>(nullable: true),
                    STYLE_NAME = table.Column<string>(nullable: true),
                    FABRIC_WIDTH = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    BUY = table.Column<DateTime>(nullable: false),
                    SUPPLIER_TYPE = table.Column<string>(nullable: true),
                    YEAR_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FABRIC_LIBRARY_MAIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "L_BASIC_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    KEY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_BASIC_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "L_BRAND",
                columns: table => new
                {
                    BRAND_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BRAND_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_BRAND", x => x.BRAND_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_COUNTRY",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    COUNTRY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_COUNTRY", x => x.COUNTRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_DELIVERY_PLACE",
                columns: table => new
                {
                    DELIVERY_PLACE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    COUNTRY_ID = table.Column<int>(nullable: false),
                    DELIVERY_PLACE_NAME = table.Column<string>(nullable: false),
                    DELIVERY_PORT_CODE = table.Column<string>(nullable: true),
                    WAREHOUSE = table.Column<string>(nullable: true),
                    WAREHOUSE_ADDRESS = table.Column<string>(nullable: true),
                    PERSON_IN_CHARGE = table.Column<string>(nullable: true),
                    TELEPHONE_NO = table.Column<string>(nullable: true),
                    REMARKS = table.Column<string>(nullable: true),
                    ZONE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_DELIVERY_PLACE", x => x.DELIVERY_PLACE_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_EXPORTER",
                columns: table => new
                {
                    EXPORTER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    EXPORTER_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_EXPORTER", x => x.EXPORTER_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_FABRIC_BASIC_NAME",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FABRIC_BASIC_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_FABRIC_BASIC_NAME", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "L_FABRIC_MILL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    MILL_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_FABRIC_MILL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "L_FINISH_GOODS_ITEM",
                columns: table => new
                {
                    FINISH_GOODS_ITEM_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FINISH_GOODS_ITEM_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_FINISH_GOODS_ITEM", x => x.FINISH_GOODS_ITEM_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_IMPORTER",
                columns: table => new
                {
                    IMPORTER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    IMPORTER_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_IMPORTER", x => x.IMPORTER_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_LANDING_PORT",
                columns: table => new
                {
                    LANDING_PORT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    LANDING_PORT_NAME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_LANDING_PORT", x => x.LANDING_PORT_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_ORDER_TYPE",
                columns: table => new
                {
                    ORDER_TYPE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    ORDER_TYPE_NAME = table.Column<string>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_ORDER_TYPE", x => x.ORDER_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_SAMPLE_TYPE",
                columns: table => new
                {
                    SAMPLE_TYPE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SAMPLE_TYPE_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SAMPLE_TYPE", x => x.SAMPLE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_SEASON",
                columns: table => new
                {
                    SEASON_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SEASON_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SEASON", x => x.SEASON_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_SHIPPED_TYPE",
                columns: table => new
                {
                    SHIPPED_TYPE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SHIPPED_TYPE_NAME = table.Column<string>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SHIPPED_TYPE", x => x.SHIPPED_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_SIZE",
                columns: table => new
                {
                    SIZE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SIZE_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SIZE", x => x.SIZE_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_UNIT",
                columns: table => new
                {
                    UNIT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    UNIT_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_UNIT", x => x.UNIT_ID);
                });

            migrationBuilder.CreateTable(
                name: "L_UNIT_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    UNIT_NAME = table.Column<string>(nullable: true),
                    SHORT_NAME = table.Column<string>(nullable: true),
                    METHOD_ID = table.Column<int>(nullable: false),
                    TYPE = table.Column<string>(nullable: true),
                    DEFAULT_VALUE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_UNIT_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoggerEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserIp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggerEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_FACTORY_SETTING",
                columns: table => new
                {
                    FACTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FACTORY_NAME = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FACTORY_SETTING", x => x.FACTORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FILE_OBJECT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    KEY = table.Column<string>(nullable: true),
                    REF_TABLE = table.Column<string>(nullable: true),
                    HEADER = table.Column<string>(nullable: true),
                    REMARKS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FILE_OBJECT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST",
                columns: table => new
                {
                    FORECAST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    FG_SIZE_CODE = table.Column<string>(nullable: true),
                    FG_SIZE = table.Column<string>(nullable: true),
                    SEASON_ID = table.Column<int>(nullable: false),
                    YEAR_ID = table.Column<int>(nullable: false),
                    DATA_YEAR_ID = table.Column<int>(nullable: false),
                    WEEK_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false),
                    FILE_UPLOAD_DATE = table.Column<DateTime>(nullable: true),
                    WEEK1 = table.Column<int>(nullable: false),
                    WEEK2 = table.Column<int>(nullable: false),
                    WEEK3 = table.Column<int>(nullable: false),
                    WEEK4 = table.Column<int>(nullable: false),
                    WEEK5 = table.Column<int>(nullable: false),
                    WEEK6 = table.Column<int>(nullable: false),
                    WEEK7 = table.Column<int>(nullable: false),
                    WEEK8 = table.Column<int>(nullable: false),
                    WEEK9 = table.Column<int>(nullable: false),
                    WEEK10 = table.Column<int>(nullable: false),
                    WEEK11 = table.Column<int>(nullable: false),
                    WEEK12 = table.Column<int>(nullable: false),
                    WEEK13 = table.Column<int>(nullable: false),
                    WEEK14 = table.Column<int>(nullable: false),
                    WEEK15 = table.Column<int>(nullable: false),
                    WEEK16 = table.Column<int>(nullable: false),
                    WEEK17 = table.Column<int>(nullable: false),
                    WEEK18 = table.Column<int>(nullable: false),
                    WEEK19 = table.Column<int>(nullable: false),
                    WEEK20 = table.Column<int>(nullable: false),
                    WEEK21 = table.Column<int>(nullable: false),
                    WEEK22 = table.Column<int>(nullable: false),
                    WEEK23 = table.Column<int>(nullable: false),
                    WEEK24 = table.Column<int>(nullable: false),
                    WEEK25 = table.Column<int>(nullable: false),
                    WEEK26 = table.Column<int>(nullable: false),
                    WEEK27 = table.Column<int>(nullable: false),
                    WEEK28 = table.Column<int>(nullable: false),
                    WEEK29 = table.Column<int>(nullable: false),
                    WEEK30 = table.Column<int>(nullable: false),
                    WEEK31 = table.Column<int>(nullable: false),
                    WEEK32 = table.Column<int>(nullable: false),
                    WEEK33 = table.Column<int>(nullable: false),
                    WEEK34 = table.Column<int>(nullable: false),
                    WEEK35 = table.Column<int>(nullable: false),
                    WEEK36 = table.Column<int>(nullable: false),
                    WEEK37 = table.Column<int>(nullable: false),
                    WEEK38 = table.Column<int>(nullable: false),
                    WEEK39 = table.Column<int>(nullable: false),
                    WEEK40 = table.Column<int>(nullable: false),
                    WEEK41 = table.Column<int>(nullable: false),
                    WEEK42 = table.Column<int>(nullable: false),
                    WEEK43 = table.Column<int>(nullable: false),
                    WEEK44 = table.Column<int>(nullable: false),
                    WEEK45 = table.Column<int>(nullable: false),
                    WEEK46 = table.Column<int>(nullable: false),
                    WEEK47 = table.Column<int>(nullable: false),
                    WEEK48 = table.Column<int>(nullable: false),
                    WEEK49 = table.Column<int>(nullable: false),
                    WEEK50 = table.Column<int>(nullable: false),
                    WEEK51 = table.Column<int>(nullable: false),
                    WEEK52 = table.Column<int>(nullable: false),
                    WEEK53 = table.Column<int>(nullable: false),
                    SEASON_YEAR_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST", x => x.FORECAST_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST_BOOKING_DETAILS",
                columns: table => new
                {
                    FORECAST_BOOKING_DETAILS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    FG_SIZE_CODE = table.Column<string>(nullable: true),
                    FG_SIZE = table.Column<string>(nullable: true),
                    SEASON_ID = table.Column<int>(nullable: false),
                    YEAR_ID = table.Column<int>(nullable: false),
                    DATA_YEAR_ID = table.Column<int>(nullable: false),
                    WEEK_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false),
                    FILE_UPLOAD_DATE = table.Column<DateTime>(nullable: true),
                    WEEK1 = table.Column<int>(nullable: false),
                    WEEK2 = table.Column<int>(nullable: false),
                    WEEK3 = table.Column<int>(nullable: false),
                    WEEK4 = table.Column<int>(nullable: false),
                    WEEK5 = table.Column<int>(nullable: false),
                    WEEK6 = table.Column<int>(nullable: false),
                    WEEK7 = table.Column<int>(nullable: false),
                    WEEK8 = table.Column<int>(nullable: false),
                    WEEK9 = table.Column<int>(nullable: false),
                    WEEK10 = table.Column<int>(nullable: false),
                    WEEK11 = table.Column<int>(nullable: false),
                    WEEK12 = table.Column<int>(nullable: false),
                    WEEK13 = table.Column<int>(nullable: false),
                    WEEK14 = table.Column<int>(nullable: false),
                    WEEK15 = table.Column<int>(nullable: false),
                    WEEK16 = table.Column<int>(nullable: false),
                    WEEK17 = table.Column<int>(nullable: false),
                    WEEK18 = table.Column<int>(nullable: false),
                    WEEK19 = table.Column<int>(nullable: false),
                    WEEK20 = table.Column<int>(nullable: false),
                    WEEK21 = table.Column<int>(nullable: false),
                    WEEK22 = table.Column<int>(nullable: false),
                    WEEK23 = table.Column<int>(nullable: false),
                    WEEK24 = table.Column<int>(nullable: false),
                    WEEK25 = table.Column<int>(nullable: false),
                    WEEK26 = table.Column<int>(nullable: false),
                    WEEK27 = table.Column<int>(nullable: false),
                    WEEK28 = table.Column<int>(nullable: false),
                    WEEK29 = table.Column<int>(nullable: false),
                    WEEK30 = table.Column<int>(nullable: false),
                    WEEK31 = table.Column<int>(nullable: false),
                    WEEK32 = table.Column<int>(nullable: false),
                    WEEK33 = table.Column<int>(nullable: false),
                    WEEK34 = table.Column<int>(nullable: false),
                    WEEK35 = table.Column<int>(nullable: false),
                    WEEK36 = table.Column<int>(nullable: false),
                    WEEK37 = table.Column<int>(nullable: false),
                    WEEK38 = table.Column<int>(nullable: false),
                    WEEK39 = table.Column<int>(nullable: false),
                    WEEK40 = table.Column<int>(nullable: false),
                    WEEK41 = table.Column<int>(nullable: false),
                    WEEK42 = table.Column<int>(nullable: false),
                    WEEK43 = table.Column<int>(nullable: false),
                    WEEK44 = table.Column<int>(nullable: false),
                    WEEK45 = table.Column<int>(nullable: false),
                    WEEK46 = table.Column<int>(nullable: false),
                    WEEK47 = table.Column<int>(nullable: false),
                    WEEK48 = table.Column<int>(nullable: false),
                    WEEK49 = table.Column<int>(nullable: false),
                    WEEK50 = table.Column<int>(nullable: false),
                    WEEK51 = table.Column<int>(nullable: false),
                    WEEK52 = table.Column<int>(nullable: false),
                    WEEK53 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST_BOOKING_DETAILS", x => x.FORECAST_BOOKING_DETAILS_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST_BOOKING_SUMMARY",
                columns: table => new
                {
                    FORECAST_BOOKING_SUMMARY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    YEAR_ID = table.Column<int>(nullable: false),
                    WEEK_ID = table.Column<int>(nullable: false),
                    DATA_YEAR_ID = table.Column<int>(nullable: false),
                    FG_MODEL = table.Column<string>(nullable: true),
                    FORECAST_BOOKING_QTY = table.Column<double>(nullable: false),
                    SEASON_YEAR_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST_BOOKING_SUMMARY", x => x.FORECAST_BOOKING_SUMMARY_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST_INSTRUCTION",
                columns: table => new
                {
                    FORECAST_INSTRUCTION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SPL = table.Column<string>(nullable: true),
                    STYLE = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    RDSW_BOOKING = table.Column<double>(nullable: false),
                    BIDSW_GIVING = table.Column<double>(nullable: false),
                    STOCK = table.Column<double>(nullable: false),
                    PERCENTAGE = table.Column<double>(nullable: false),
                    NEED_TO_BOOK = table.Column<double>(nullable: false),
                    PREV_RECV = table.Column<double>(nullable: false),
                    PREV_BOOKING = table.Column<double>(nullable: false),
                    GAP_OF_RECV = table.Column<double>(nullable: false),
                    GAP_OF_BOOKING = table.Column<double>(nullable: false),
                    COMMENT = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    SEASON_YEAR_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST_INSTRUCTION", x => x.FORECAST_INSTRUCTION_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST_WEEK",
                columns: table => new
                {
                    WEEK_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    WEEK_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST_WEEK", x => x.WEEK_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_FORECAST_YEAR",
                columns: table => new
                {
                    YEAR_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    YEAR_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FORECAST_YEAR", x => x.YEAR_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_SIZE_SETUP_SETTING",
                columns: table => new
                {
                    SIZE_SETUP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SIZE_CODE = table.Column<string>(nullable: true),
                    SIZE_NAME = table.Column<string>(nullable: true),
                    INSEAM_OR_DIM = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_SIZE_SETUP_SETTING", x => x.SIZE_SETUP_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_STYLE_PART_SETUP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    PART_NAME = table.Column<string>(nullable: true),
                    REMARKS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_STYLE_PART_SETUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "M_STYLE_SETTING",
                columns: table => new
                {
                    STYLE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    ITEM = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    SMV = table.Column<string>(nullable: true),
                    BUYER_DEPARTMENT = table.Column<string>(nullable: true),
                    FILE_PATH = table.Column<string>(nullable: true),
                    BRAND_ID = table.Column<int>(nullable: false),
                    MAIN_FABRIC = table.Column<string>(nullable: true),
                    TARGET_FOB = table.Column<double>(nullable: false),
                    GMT_ITEM_ID = table.Column<int>(nullable: false),
                    BUYER_DEPARTMENT_ID = table.Column<int>(nullable: false),
                    SIZE_RANGE_ID = table.Column<int>(nullable: false),
                    STATUS = table.Column<string>(nullable: true),
                    REF_STYLE_ID = table.Column<int>(nullable: false),
                    COLOR_TYPE = table.Column<string>(nullable: true),
                    NO_OF_COLOR = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    COLOR_LOT = table.Column<string>(nullable: true),
                    CAD_DATE = table.Column<DateTime>(nullable: false),
                    YearId = table.Column<int>(nullable: false),
                    UpdateFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_STYLE_SETTING", x => x.STYLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_TECH_PACK_MASTER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    STYLE_ID = table.Column<int>(nullable: false),
                    CURRENT_DATE = table.Column<DateTime>(nullable: false),
                    SL_NO = table.Column<int>(nullable: false),
                    FILE_PATH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_TECH_PACK_MASTER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MENU_MAIN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    MENU_NAME = table.Column<string>(nullable: true),
                    ACTIVE_STATUS = table.Column<bool>(nullable: false),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_MAIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_INSTRUCTION",
                columns: table => new
                {
                    BOOKING_INSTRUCTION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SPL = table.Column<string>(nullable: true),
                    SEASON_ID = table.Column<int>(nullable: false),
                    STYLE_NO = table.Column<string>(nullable: true),
                    STYLE_ID = table.Column<int>(nullable: false),
                    MODEL_NO = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    GLOBAL_SELECTION = table.Column<double>(nullable: false),
                    EUROPE_SELECTION = table.Column<double>(nullable: false),
                    TOTAL_RECEIVED = table.Column<double>(nullable: false),
                    TOTAL_BOOKING = table.Column<double>(nullable: false),
                    TOTAL_STOCK = table.Column<double>(nullable: false),
                    EUSS = table.Column<double>(nullable: false),
                    EUAW = table.Column<double>(nullable: false),
                    EUROPE_ELASTICITY = table.Column<string>(nullable: true),
                    EUROPE_SUPPLY = table.Column<string>(nullable: true),
                    EUROPE_RECEIVED = table.Column<double>(nullable: false),
                    EUROPE_BOOKING = table.Column<double>(nullable: false),
                    MOROCCO = table.Column<double>(nullable: false),
                    MOROCCO_ELASTICITY = table.Column<string>(nullable: true),
                    MOROCCO_SUPPLY = table.Column<string>(nullable: true),
                    MOROCCO_RECEIVED = table.Column<double>(nullable: false),
                    MOROCCO_BOOKING = table.Column<double>(nullable: false),
                    TURKEY = table.Column<double>(nullable: false),
                    TURKEY_ELASTICITY = table.Column<string>(nullable: true),
                    TURKEY_SUPPLY = table.Column<string>(nullable: true),
                    TURKEY_RECEIVED = table.Column<double>(nullable: false),
                    TURKEY_BOOKING = table.Column<double>(nullable: false),
                    RUSSIA = table.Column<double>(nullable: false),
                    RUSSIA_ELASTICITY = table.Column<string>(nullable: true),
                    RUSSIA_SUPPLY = table.Column<string>(nullable: true),
                    RUSSIA_RECEIVED = table.Column<double>(nullable: false),
                    RUSSIA_BOOKING = table.Column<double>(nullable: false),
                    INDIA = table.Column<double>(nullable: false),
                    INDIA_ELASTICITY = table.Column<string>(nullable: true),
                    INDIA_SUPPLY = table.Column<string>(nullable: true),
                    INDIA_RECEIVED = table.Column<double>(nullable: false),
                    INDIA_BOOKING = table.Column<double>(nullable: false),
                    BRAZIL = table.Column<double>(nullable: false),
                    BRAZIL_ELASTICITY = table.Column<string>(nullable: true),
                    BRAZIL_SUPPLY = table.Column<string>(nullable: true),
                    BRAZIL_RECEIVED = table.Column<double>(nullable: false),
                    BRAZIL_BOOKING = table.Column<double>(nullable: false),
                    ASIA = table.Column<double>(nullable: false),
                    ASIA_ELASTICITY = table.Column<string>(nullable: true),
                    ASIA_SUPPLY = table.Column<string>(nullable: true),
                    ASIA_RECEIVED = table.Column<double>(nullable: false),
                    ASIA_BOOKING = table.Column<double>(nullable: false),
                    AMERICA = table.Column<double>(nullable: false),
                    AMERICA_ELASTICITY = table.Column<string>(nullable: true),
                    AMERICA_SUPPLY = table.Column<string>(nullable: true),
                    AMERICA_RECEIVED = table.Column<double>(nullable: false),
                    AMERICA_BOOKING = table.Column<double>(nullable: false),
                    CHINA = table.Column<double>(nullable: false),
                    CHINA_ELASTICITY = table.Column<string>(nullable: true),
                    CHINA_SUPPLY = table.Column<string>(nullable: true),
                    CHINA_RECEIVED = table.Column<double>(nullable: false),
                    CHINA_BOOKING = table.Column<double>(nullable: false),
                    CANADA = table.Column<double>(nullable: false),
                    CANADA_ELASTICITY = table.Column<string>(nullable: true),
                    CANADA_SUPPLY = table.Column<string>(nullable: true),
                    CANADA_RECEIVED = table.Column<double>(nullable: false),
                    CANADA_BOOKING = table.Column<double>(nullable: false),
                    INDIAN_OCEAN = table.Column<double>(nullable: false),
                    INDIAN_OCEAN_ELASTICITY = table.Column<string>(nullable: true),
                    INDIAN_OCEAN_SUPPLY = table.Column<string>(nullable: true),
                    INDIAN_OCEAN_RECEIVED = table.Column<double>(nullable: false),
                    INDIAN_OCEAN_BOOKING = table.Column<double>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false),
                    SEASON_YEAR_ID = table.Column<int>(nullable: false),
                    DEL_DATE = table.Column<DateTime>(nullable: true),
                    UNIT_PRICE = table.Column<double>(nullable: false),
                    BRAND_ID = table.Column<int>(nullable: true),
                    STOCK_COMMENTS = table.Column<string>(nullable: true),
                    DEL_STATUS = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_INSTRUCTION", x => x.BOOKING_INSTRUCTION_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_ITEM",
                columns: table => new
                {
                    BOOKING_ITEM_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BOOKING_ITEM_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_ITEM", x => x.BOOKING_ITEM_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_MAIN",
                columns: table => new
                {
                    BOOKING_MAIN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    STYLE_NO = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    RECEIVED_QTY = table.Column<double>(nullable: false),
                    TOTAL_BOOKING = table.Column<double>(nullable: false),
                    GLOBAL_SELECTION_MAIN = table.Column<double>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_MAIN", x => x.BOOKING_MAIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_SIZE_WISE_MAIN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    STYLE_NO = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    FG_SIZE = table.Column<string>(nullable: true),
                    RECEIVED_QTY = table.Column<double>(nullable: false),
                    TOTAL_BOOKING = table.Column<double>(nullable: false),
                    GLOBAL_SELECTION_MAIN = table.Column<double>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_SIZE_WISE_MAIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_SIZE_WISE_SUB",
                columns: table => new
                {
                    BOOKING_SIZE_WISE_SUB_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BOOKING_ITEM_ID = table.Column<int>(nullable: false),
                    SUPPLIER_ID = table.Column<int>(nullable: false),
                    MODEL = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    COLOR_CODE = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    CUTTING_CONSUM = table.Column<double>(nullable: false),
                    BOOKING_CONSUM = table.Column<double>(nullable: false),
                    WASTAGE = table.Column<double>(nullable: false),
                    PROJECTION_QTY = table.Column<double>(nullable: false),
                    PROJECTION_BOOKING = table.Column<double>(nullable: false),
                    RECEIVED_QTY = table.Column<double>(nullable: false),
                    RECEIVED_BOOKING = table.Column<double>(nullable: false),
                    BOOKING_INSTRUCTION = table.Column<double>(nullable: false),
                    BOOKING_INSTRUCTION_QTY = table.Column<double>(nullable: false),
                    TOTAL_BOOKING = table.Column<double>(nullable: false),
                    ALREADY_BOOKED = table.Column<double>(nullable: false),
                    NEW_BOOKING = table.Column<double>(nullable: false),
                    CREATE_PO = table.Column<string>(nullable: true),
                    TOTAL_IN_HOUSE_PCS = table.Column<double>(nullable: false),
                    MEASUREMENT = table.Column<string>(nullable: true),
                    BOOKING_SIZE_WISE_MAIN_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_SIZE_WISE_SUB", x => x.BOOKING_SIZE_WISE_SUB_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_PURCHASE_ORDER",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    ORDER_NAME = table.Column<string>(nullable: true),
                    ORDER_NO = table.Column<string>(nullable: true),
                    STYLE_NO = table.Column<string>(nullable: true),
                    MODEL = table.Column<string>(nullable: true),
                    ITEM = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    SIZE_VALUE = table.Column<string>(nullable: true),
                    ORDER_QTY = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<int>(nullable: false),
                    ORDER_TYPE_ID = table.Column<int>(nullable: false),
                    ORDER_TYPE_NAME = table.Column<string>(nullable: true),
                    DELIVERY_PLACE_ID = table.Column<int>(nullable: false),
                    PORT_OF_DESTINATION_NAME = table.Column<string>(nullable: true),
                    SHIPPED_TYPE_ID = table.Column<int>(nullable: false),
                    SHIPPED_TYPE_NAME = table.Column<string>(nullable: true),
                    LANDING_PORT_ID = table.Column<int>(nullable: false),
                    PORT_OF_LANDING_NAME = table.Column<string>(nullable: true),
                    ITEM_DESCRIPTION = table.Column<string>(nullable: true),
                    PCB_VALUE = table.Column<int>(nullable: false),
                    UE_VALUE = table.Column<int>(nullable: false),
                    PACKAGING = table.Column<string>(nullable: true),
                    SHIPPED_QTY = table.Column<int>(nullable: false),
                    REMAIN_QTY = table.Column<int>(nullable: false),
                    UNIT_PRICE = table.Column<double>(nullable: false),
                    TOTAL_PRICE = table.Column<double>(nullable: false),
                    CREATION_DATE = table.Column<DateTime>(nullable: true),
                    CONTRACTUAL_DELIVERY_DATE = table.Column<DateTime>(nullable: true),
                    HAND_OVER_DATE = table.Column<DateTime>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    REMARKS = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    FILE_TRACK_NO = table.Column<int>(nullable: false),
                    ACTIVE_STATUS = table.Column<string>(nullable: true),
                    PARENT_ID = table.Column<int>(nullable: false),
                    ORDER_MANAGEMENT_ID = table.Column<int>(nullable: false),
                    YEAR_ID = table.Column<int>(nullable: false),
                    PO_STATUS = table.Column<string>(nullable: true),
                    COMPANY_ID = table.Column<int>(nullable: false),
                    FOC = table.Column<double>(nullable: false),
                    LineNo = table.Column<string>(nullable: true),
                    QtNumber = table.Column<string>(nullable: true),
                    SalesContract = table.Column<string>(nullable: true),
                    TentativeMatarialsInhouseDate = table.Column<string>(nullable: true),
                    TmrInhouseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_PURCHASE_ORDER", x => x.ORDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_SAMPLE_DEV_DETAIL",
                columns: table => new
                {
                    SAMPLE_DEVELOPMENT_DETAIL_ID = table.Column<string>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SAMPLE_SIZE = table.Column<string>(nullable: true),
                    SAMPLE_QUANTITY = table.Column<int>(nullable: false),
                    SAMPLE_DEVELOPMENT_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_SAMPLE_DEV_DETAIL", x => x.SAMPLE_DEVELOPMENT_DETAIL_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_SAMPLE_DEV_MASTER",
                columns: table => new
                {
                    SAMPLE_DEVELOPMENT_ID = table.Column<string>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SEASON_ID = table.Column<string>(nullable: true),
                    BRAND_ID = table.Column<string>(nullable: true),
                    STYLE_NO = table.Column<string>(nullable: true),
                    MPC = table.Column<string>(nullable: true),
                    ORDER_TYPE = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    SAMPLE_TYPE_ID = table.Column<string>(nullable: true),
                    FG_MODEL = table.Column<string>(nullable: true),
                    FINISH_GOODS_ITEM_ID = table.Column<string>(nullable: true),
                    SAMPLE_REQUEST_DATE = table.Column<DateTime>(nullable: true),
                    TECHPACK_STATUS = table.Column<string>(nullable: true),
                    SAMPLE_SUBMISSION_DATE = table.Column<DateTime>(nullable: true),
                    SUB_SECTION_ID = table.Column<string>(nullable: true),
                    MATERIAL_IN_HOUSE_DATE = table.Column<DateTime>(nullable: true),
                    MASTER_SAMPLE_SEND_DATE_FOR_TESTING = table.Column<DateTime>(nullable: true),
                    MASTER_SAMPLE_TEST_REPORT_NO = table.Column<string>(nullable: true),
                    MASTER_SAMPLE_TEST_RESULT = table.Column<string>(nullable: true),
                    SAMPLE_SUBMITTED_DATE = table.Column<DateTime>(nullable: true),
                    SAMPLE_COMMENT_DATE = table.Column<DateTime>(nullable: true),
                    SAMPLE_STATUS = table.Column<string>(nullable: true),
                    BUYER_COMMENT_ON_SAMPLE = table.Column<string>(nullable: true),
                    REMARK = table.Column<string>(nullable: true),
                    TEST_REQUIREMENT = table.Column<string>(nullable: true),
                    LINE_START_DATE = table.Column<DateTime>(nullable: true),
                    PRODUCTION_SAMPLE_SEND_DATE_TESTING = table.Column<DateTime>(nullable: true),
                    PRODUCTION_TEST_REPORT_NO = table.Column<string>(nullable: true),
                    PRODUCTION_TEST_RESULT = table.Column<string>(nullable: true),
                    SHIPMENT_DATE = table.Column<DateTime>(nullable: true),
                    PO_NO = table.Column<string>(nullable: true),
                    SAM = table.Column<string>(nullable: true),
                    BUYER_CONCERN = table.Column<string>(nullable: true),
                    RECEIVED_CONFIRMATION = table.Column<string>(nullable: true),
                    SAMPLE_ROOM_COMMENTS = table.Column<string>(nullable: true),
                    ALL_MATERIAL_RECEIVED_DATE = table.Column<DateTime>(nullable: true),
                    TRIM_CARD_RECEIVED_DATE = table.Column<DateTime>(nullable: true),
                    TECH_PACK_ON_SAMPLE = table.Column<string>(nullable: true),
                    SAMPLE_DONE_DATE = table.Column<DateTime>(nullable: true),
                    FABRICATION = table.Column<string>(nullable: true),
                    DATA_SHEET_SENDING_DATE = table.Column<DateTime>(nullable: true),
                    TRIM_CARD_SUBMISSION_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY_SAMPLE_ROOM = table.Column<string>(nullable: true),
                    UPDATE_DATE_SAMPLE_ROOM = table.Column<DateTime>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    YEAR_ID = table.Column<int>(nullable: false),
                    PATTERN_DATE = table.Column<DateTime>(nullable: true),
                    PatternStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_SAMPLE_DEV_MASTER", x => x.SAMPLE_DEVELOPMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_SAMPLE_DEV_SR_COMMENT",
                columns: table => new
                {
                    SAMPLE_ROOM_COMMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SAMPLE_ROOM_COMMENT = table.Column<string>(nullable: true),
                    SAMPLE_ROOM_COMMENT_DATE = table.Column<DateTime>(nullable: true),
                    SAMPLE_ROOM_COMMENT_STATUS = table.Column<bool>(nullable: false),
                    MERCHANT_COMMNENT = table.Column<string>(nullable: true),
                    MERCHANT_COMMENT_DATE = table.Column<DateTime>(nullable: true),
                    MERCHANT_COMMENT_STATUS = table.Column<bool>(nullable: false),
                    SAMPLE_DEVELOPMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_SAMPLE_DEV_SR_COMMENT", x => x.SAMPLE_ROOM_COMMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_SUPPLIER",
                columns: table => new
                {
                    SUPPLIER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SUPPLIER_NAME = table.Column<string>(nullable: true),
                    SUPPLIER_ADDRESS = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    COUNTRY_ID = table.Column<int>(nullable: false),
                    CONTACT_PERSON = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    MOBILE_NO = table.Column<string>(nullable: true),
                    MATERIAL_TYPE = table.Column<string>(nullable: true),
                    SupplierStrength = table.Column<string>(nullable: true),
                    PortofLoading = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankAddress = table.Column<string>(nullable: true),
                    SwiftCode = table.Column<string>(nullable: true),
                    PaymentTerm = table.Column<string>(nullable: true),
                    MaterialTypeId = table.Column<int>(nullable: false),
                    PortOfLoadingId = table.Column<int>(nullable: false),
                    SupplierSendingAddress = table.Column<string>(nullable: true),
                    Moq = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    LeadTime = table.Column<int>(nullable: false),
                    VerifyStatus = table.Column<int>(nullable: false),
                    VerifyBy = table.Column<string>(nullable: true),
                    VerifyDate = table.Column<DateTime>(nullable: true),
                    DeliveryMode = table.Column<int>(nullable: false),
                    PortOfDestination = table.Column<int>(nullable: false),
                    PaymentMode = table.Column<int>(nullable: false),
                    Tenor = table.Column<int>(nullable: false),
                    TenorType = table.Column<int>(nullable: false),
                    TermOfDelivery = table.Column<int>(nullable: false),
                    Nomination = table.Column<string>(nullable: true),
                    SupplierMstId = table.Column<int>(nullable: false),
                    SupplierContractPerson = table.Column<string>(nullable: true),
                    SupplierContractMobile = table.Column<string>(nullable: true),
                    SupplierContractEmail = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_SUPPLIER", x => x.SUPPLIER_ID);
                });

            migrationBuilder.CreateTable(
                name: "STYLE_INFO",
                columns: table => new
                {
                    STYLE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STYLE_INFO", x => x.STYLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "FABRIC_LIBRARY_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FABRIC_LIBRARY_MAIN_ID = table.Column<int>(nullable: false),
                    SUP_BYR_COLOR_CODE = table.Column<string>(nullable: true),
                    SUP_BYR_COLOR_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FABRIC_LIBRARY_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FABRIC_LIBRARY_DETAILS_FABRIC_LIBRARY_MAIN_FABRIC_LIBRARY_MAIN_ID",
                        column: x => x.FABRIC_LIBRARY_MAIN_ID,
                        principalTable: "FABRIC_LIBRARY_MAIN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "L_REFERENCES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BASIC_TYPE_ID = table.Column<int>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    DEFAULT_UNIT = table.Column<int>(nullable: false),
                    REMARKS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_REFERENCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_L_REFERENCES_L_BASIC_TYPE_BASIC_TYPE_ID",
                        column: x => x.BASIC_TYPE_ID,
                        principalTable: "L_BASIC_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "L_DEPARTMENT",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    DEPARTMENT_NAME = table.Column<string>(nullable: true),
                    UNIT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_DEPARTMENT", x => x.DEPARTMENT_ID);
                    table.ForeignKey(
                        name: "FK_L_DEPARTMENT_L_UNIT_UNIT_ID",
                        column: x => x.UNIT_ID,
                        principalTable: "L_UNIT",
                        principalColumn: "UNIT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_FILE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FILE_OBJECT_ID = table.Column<int>(nullable: false),
                    REF_ID = table.Column<int>(nullable: false),
                    FILE_TYPE = table.Column<string>(nullable: true),
                    FILE_SIZE = table.Column<long>(nullable: false),
                    LOCATION = table.Column<string>(nullable: true),
                    DOC_TITLE = table.Column<string>(nullable: true),
                    VERSION = table.Column<int>(nullable: false),
                    ACTIVE_STATUS = table.Column<string>(nullable: true),
                    OWNER = table.Column<string>(nullable: true),
                    FILE_COMMENT = table.Column<string>(nullable: true),
                    FILE_NAME = table.Column<string>(nullable: true),
                    UPLOAD_DATE = table.Column<DateTime>(nullable: false),
                    StyleFabricId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_FILE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_M_FILE_M_FILE_OBJECT_FILE_OBJECT_ID",
                        column: x => x.FILE_OBJECT_ID,
                        principalTable: "M_FILE_OBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_COLOR_SETTING",
                columns: table => new
                {
                    COLOR_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    FG_MODEL = table.Column<string>(nullable: true),
                    COLOR_NAME = table.Column<string>(nullable: true),
                    BUYER_ID = table.Column<int>(nullable: false),
                    STYLE_SETTING_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_COLOR_SETTING", x => x.COLOR_ID);
                    table.ForeignKey(
                        name: "FK_M_COLOR_SETTING_M_STYLE_SETTING_STYLE_SETTING_ID",
                        column: x => x.STYLE_SETTING_ID,
                        principalTable: "M_STYLE_SETTING",
                        principalColumn: "STYLE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_STYLE_PART_INFO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    STYLE_SETTING_ID = table.Column<int>(nullable: false),
                    STYLE_PART_SETUP_ID = table.Column<int>(nullable: false),
                    REMARKS = table.Column<string>(nullable: true),
                    UpdateFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_STYLE_PART_INFO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_M_STYLE_PART_INFO_M_STYLE_PART_SETUP_STYLE_PART_SETUP_ID",
                        column: x => x.STYLE_PART_SETUP_ID,
                        principalTable: "M_STYLE_PART_SETUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_M_STYLE_PART_INFO_M_STYLE_SETTING_STYLE_SETTING_ID",
                        column: x => x.STYLE_SETTING_ID,
                        principalTable: "M_STYLE_SETTING",
                        principalColumn: "STYLE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_TECH_PACK_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    TECH_PACK_MASTER_ID = table.Column<int>(nullable: false),
                    COLOR = table.Column<string>(nullable: true),
                    COLOR_CODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_TECH_PACK_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_M_TECH_PACK_DETAILS_M_TECH_PACK_MASTER_TECH_PACK_MASTER_ID",
                        column: x => x.TECH_PACK_MASTER_ID,
                        principalTable: "M_TECH_PACK_MASTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MENU_SUB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    MENU_SUB_NAME = table.Column<string>(nullable: true),
                    ACTIVE_STATUS = table.Column<bool>(nullable: false),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    MENU_MAIN_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_SUB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENU_SUB_MENU_MAIN_MENU_MAIN_ID",
                        column: x => x.MENU_MAIN_ID,
                        principalTable: "MENU_MAIN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MRCNT_BOOKING_WITHOUT_SIZE",
                columns: table => new
                {
                    BOOKING_WITHOUT_SIZE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    BOOKING_ITEM_ID = table.Column<int>(nullable: false),
                    BOOKING_ITEM_NAME = table.Column<string>(nullable: true),
                    SUPPLIER_ID = table.Column<int>(nullable: false),
                    SUPPLIER_NAME = table.Column<string>(nullable: true),
                    MODEL = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    COLOR_CODE = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    CUTTING_CONSUM = table.Column<double>(nullable: false),
                    BOOKING_CONSUM = table.Column<double>(nullable: false),
                    WASTAGE = table.Column<double>(nullable: false),
                    PROJECTION_QTY = table.Column<double>(nullable: false),
                    PROJECTION_BOOKING = table.Column<double>(nullable: false),
                    RECEIVED_QTY = table.Column<double>(nullable: false),
                    RECEIVED_BOOKING = table.Column<double>(nullable: false),
                    BOOKING_INSTRUCTION = table.Column<double>(nullable: false),
                    BOOKING_INSTRUCTION_QTY = table.Column<double>(nullable: false),
                    TOTAL_BOOKING = table.Column<double>(nullable: false),
                    ALREADY_BOOKED = table.Column<double>(nullable: false),
                    NEW_BOOKING = table.Column<double>(nullable: false),
                    CREATE_PO = table.Column<string>(nullable: true),
                    TOTAL_IN_HOUSE_PCS = table.Column<double>(nullable: false),
                    BOOKING_MAIN_MODEL_ID = table.Column<int>(nullable: false),
                    BUYER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCNT_BOOKING_WITHOUT_SIZE", x => x.BOOKING_WITHOUT_SIZE_ID);
                    table.ForeignKey(
                        name: "FK_MRCNT_BOOKING_WITHOUT_SIZE_MRCNT_BOOKING_MAIN_BOOKING_MAIN_MODEL_ID",
                        column: x => x.BOOKING_MAIN_MODEL_ID,
                        principalTable: "MRCNT_BOOKING_MAIN",
                        principalColumn: "BOOKING_MAIN_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "L_SECTION",
                columns: table => new
                {
                    SECTION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SECTION_NAME = table.Column<string>(nullable: true),
                    DEPARTMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SECTION", x => x.SECTION_ID);
                    table.ForeignKey(
                        name: "FK_L_SECTION_L_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "L_DEPARTMENT",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "M_STYLE_PROCESS",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
            //        CREATE_DATE = table.Column<DateTime>(nullable: true),
            //        UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
            //        UPDATE_DATE = table.Column<DateTime>(nullable: true),
            //        HEAD_OFFICE_ID = table.Column<int>(nullable: false),
            //        BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
            //        STYLE_PART_INFO_ID = table.Column<int>(nullable: false),
            //        ITEM_ID = table.Column<int>(nullable: false),
            //        CATEGORY_ID = table.Column<int>(nullable: false),
            //        INSTRUCTION = table.Column<string>(nullable: true),
            //        REMARKS = table.Column<string>(nullable: true),
            //        StyleSettingModelStyleId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_M_STYLE_PROCESS", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_M_STYLE_PROCESS_M_STYLE_PART_INFO_STYLE_PART_INFO_ID",
            //            column: x => x.STYLE_PART_INFO_ID,
            //            principalTable: "M_STYLE_PART_INFO",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_M_STYLE_PROCESS_M_STYLE_PART_INFO_STYLE_PART_INFO_ID1",
            //            column: x => x.STYLE_PART_INFO_ID,
            //            principalTable: "M_STYLE_PART_INFO",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_M_STYLE_PROCESS_M_STYLE_SETTING_StyleSettingModelStyleId",
            //            column: x => x.StyleSettingModelStyleId,
            //            principalTable: "M_STYLE_SETTING",
            //            principalColumn: "STYLE_ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "MENU_SUB_SUB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    MENU_NAME = table.Column<string>(nullable: true),
                    ACTIVE_STATUS = table.Column<bool>(nullable: false),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    MENU_SUB_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_SUB_SUB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENU_SUB_SUB_MENU_SUB_MENU_SUB_ID",
                        column: x => x.MENU_SUB_ID,
                        principalTable: "MENU_SUB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "L_SUB_SECTION",
                columns: table => new
                {
                    SUB_SECTION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(nullable: true),
                    UPDATE_BY = table.Column<string>(maxLength: 20, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    HEAD_OFFICE_ID = table.Column<int>(nullable: false),
                    BRANCH_OFFICE_ID = table.Column<int>(nullable: false),
                    SUB_SECTION_NAME = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_SUB_SECTION", x => x.SUB_SECTION_ID);
                    table.ForeignKey(
                        name: "FK_L_SUB_SECTION_L_SECTION_SectionId",
                        column: x => x.SectionId,
                        principalTable: "L_SECTION",
                        principalColumn: "SECTION_ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_FABRIC_LIBRARY_DETAILS_FABRIC_LIBRARY_MAIN_ID",
                table: "FABRIC_LIBRARY_DETAILS",
                column: "FABRIC_LIBRARY_MAIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_L_DEPARTMENT_UNIT_ID",
                table: "L_DEPARTMENT",
                column: "UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_L_REFERENCES_BASIC_TYPE_ID",
                table: "L_REFERENCES",
                column: "BASIC_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_L_SECTION_DEPARTMENT_ID",
                table: "L_SECTION",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_L_SUB_SECTION_SectionId",
                table: "L_SUB_SECTION",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_M_COLOR_SETTING_STYLE_SETTING_ID",
                table: "M_COLOR_SETTING",
                column: "STYLE_SETTING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_FILE_FILE_OBJECT_ID",
                table: "M_FILE",
                column: "FILE_OBJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_STYLE_PART_INFO_STYLE_PART_SETUP_ID",
                table: "M_STYLE_PART_INFO",
                column: "STYLE_PART_SETUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_STYLE_PART_INFO_STYLE_SETTING_ID",
                table: "M_STYLE_PART_INFO",
                column: "STYLE_SETTING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_STYLE_PROCESS_STYLE_PART_INFO_ID",
                table: "M_STYLE_PROCESS",
                column: "STYLE_PART_INFO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_STYLE_PROCESS_StyleSettingModelStyleId",
                table: "M_STYLE_PROCESS",
                column: "StyleSettingModelStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_M_TECH_PACK_DETAILS_TECH_PACK_MASTER_ID",
                table: "M_TECH_PACK_DETAILS",
                column: "TECH_PACK_MASTER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_SUB_MENU_MAIN_ID",
                table: "MENU_SUB",
                column: "MENU_MAIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_SUB_SUB_MENU_SUB_ID",
                table: "MENU_SUB_SUB",
                column: "MENU_SUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MRCNT_BOOKING_WITHOUT_SIZE_BOOKING_MAIN_MODEL_ID",
                table: "MRCNT_BOOKING_WITHOUT_SIZE",
                column: "BOOKING_MAIN_MODEL_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIONS_LIST");

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
                name: "BARCODE_GEN");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_BASIC");

            migrationBuilder.DropTable(
                name: "FABRIC_DETAILS");

            migrationBuilder.DropTable(
                name: "FABRIC_LIBRARY_DETAILS");

            migrationBuilder.DropTable(
                name: "L_BRAND");

            migrationBuilder.DropTable(
                name: "L_COUNTRY");

            migrationBuilder.DropTable(
                name: "L_DELIVERY_PLACE");

            migrationBuilder.DropTable(
                name: "L_EXPORTER");

            migrationBuilder.DropTable(
                name: "L_FABRIC_BASIC_NAME");

            migrationBuilder.DropTable(
                name: "L_FABRIC_MILL");

            migrationBuilder.DropTable(
                name: "L_FINISH_GOODS_ITEM");

            migrationBuilder.DropTable(
                name: "L_IMPORTER");

            migrationBuilder.DropTable(
                name: "L_LANDING_PORT");

            migrationBuilder.DropTable(
                name: "L_ORDER_TYPE");

            migrationBuilder.DropTable(
                name: "L_REFERENCES");

            migrationBuilder.DropTable(
                name: "L_SAMPLE_TYPE");

            migrationBuilder.DropTable(
                name: "L_SEASON");

            migrationBuilder.DropTable(
                name: "L_SHIPPED_TYPE");

            migrationBuilder.DropTable(
                name: "L_SIZE");

            migrationBuilder.DropTable(
                name: "L_SUB_SECTION");

            migrationBuilder.DropTable(
                name: "L_UNIT_TYPE");

            migrationBuilder.DropTable(
                name: "LoggerEntities");

            migrationBuilder.DropTable(
                name: "M_COLOR_SETTING");

            migrationBuilder.DropTable(
                name: "M_FACTORY_SETTING");

            migrationBuilder.DropTable(
                name: "M_FILE");

            migrationBuilder.DropTable(
                name: "M_FORECAST");

            migrationBuilder.DropTable(
                name: "M_FORECAST_BOOKING_DETAILS");

            migrationBuilder.DropTable(
                name: "M_FORECAST_BOOKING_SUMMARY");

            migrationBuilder.DropTable(
                name: "M_FORECAST_INSTRUCTION");

            migrationBuilder.DropTable(
                name: "M_FORECAST_WEEK");

            migrationBuilder.DropTable(
                name: "M_FORECAST_YEAR");

            migrationBuilder.DropTable(
                name: "M_SIZE_SETUP_SETTING");

            migrationBuilder.DropTable(
                name: "M_STYLE_PROCESS");

            migrationBuilder.DropTable(
                name: "M_TECH_PACK_DETAILS");

            migrationBuilder.DropTable(
                name: "MENU_SUB_SUB");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_INSTRUCTION");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_ITEM");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_SIZE_WISE_MAIN");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_SIZE_WISE_SUB");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_WITHOUT_SIZE");

            migrationBuilder.DropTable(
                name: "MRCNT_PURCHASE_ORDER");

            migrationBuilder.DropTable(
                name: "MRCNT_SAMPLE_DEV_DETAIL");

            migrationBuilder.DropTable(
                name: "MRCNT_SAMPLE_DEV_MASTER");

            migrationBuilder.DropTable(
                name: "MRCNT_SAMPLE_DEV_SR_COMMENT");

            migrationBuilder.DropTable(
                name: "MRCNT_SUPPLIER");

            migrationBuilder.DropTable(
                name: "STYLE_INFO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FABRIC_LIBRARY_MAIN");

            migrationBuilder.DropTable(
                name: "L_BASIC_TYPE");

            migrationBuilder.DropTable(
                name: "L_SECTION");

            migrationBuilder.DropTable(
                name: "M_FILE_OBJECT");

            migrationBuilder.DropTable(
                name: "M_STYLE_PART_INFO");

            migrationBuilder.DropTable(
                name: "M_TECH_PACK_MASTER");

            migrationBuilder.DropTable(
                name: "MENU_SUB");

            migrationBuilder.DropTable(
                name: "MRCNT_BOOKING_MAIN");

            migrationBuilder.DropTable(
                name: "L_DEPARTMENT");

            migrationBuilder.DropTable(
                name: "M_STYLE_PART_SETUP");

            migrationBuilder.DropTable(
                name: "M_STYLE_SETTING");

            migrationBuilder.DropTable(
                name: "MENU_MAIN");

            migrationBuilder.DropTable(
                name: "L_UNIT");
        }
    }
}
