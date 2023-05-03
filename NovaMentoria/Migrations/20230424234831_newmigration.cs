using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovaMentoria.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Circle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Fee = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Enterprise = table.Column<string>(nullable: true),
                    Duration = table.Column<float>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeConsultor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Fee = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConsultor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
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
                    CircleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateBorn = table.Column<DateTime>(nullable: false),
                    NivelStudy = table.Column<int>(nullable: false),
                    University = table.Column<string>(nullable: true),
                    GraduateDate = table.Column<DateTime>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Enterprise = table.Column<string>(nullable: true),
                    Recommendation = table.Column<bool>(nullable: false),
                    IsStudying = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Circle_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseId = table.Column<int>(nullable: false),
                    CostCenter = table.Column<string>(nullable: true),
                    Balance = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    InitialBalance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CircleId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    TypeObject = table.Column<int>(nullable: false),
                    TypeConsultorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimePlanned = table.Column<float>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    RealTime = table.Column<float>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    Productivity = table.Column<float>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FinalValue = table.Column<float>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualState_Circle_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualState_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualState_AspNetUsers_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualState_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualState_TypeConsultor_TypeConsultorId",
                        column: x => x.TypeConsultorId,
                        principalTable: "TypeConsultor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CircleId = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: false),
                    OportunityLearning = table.Column<string>(nullable: true),
                    Note = table.Column<float>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Circle_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeId = table.Column<int>(nullable: false),
                    CircleId = table.Column<int>(nullable: false),
                    OportunityLearning = table.Column<string>(nullable: true),
                    LearningAction = table.Column<string>(nullable: true),
                    MeasurementDate = table.Column<DateTime>(nullable: false),
                    MeasurementForm = table.Column<float>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Learnings_Circle_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Learnings_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Learnings_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expensive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    CashDate = table.Column<DateTime>(nullable: false),
                    MonthDate = table.Column<DateTime>(nullable: false),
                    CompDate = table.Column<DateTime>(nullable: false),
                    DisbursementId = table.Column<int>(nullable: false),
                    CaptureId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    TargetBill = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    Plan = table.Column<bool>(nullable: false),
                    Balance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expensive_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expensive_Capture_CaptureId",
                        column: x => x.CaptureId,
                        principalTable: "Capture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expensive_CostCenter_DisbursementId",
                        column: x => x.DisbursementId,
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expensive_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HourDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualStateId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<float>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourDay_ActualState_ActualStateId",
                        column: x => x.ActualStateId,
                        principalTable: "ActualState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePerson = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    FeedbackId = table.Column<int>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_Feedback_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonFeedbacks_AspNetUsers_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeopleLearn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    LearningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleLearn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleLearn_Learnings_LearningId",
                        column: x => x.LearningId,
                        principalTable: "Learnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleLearn_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLearnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePerson = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    LearningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLearnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLearnings_Learnings_LearningId",
                        column: x => x.LearningId,
                        principalTable: "Learnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLearnings_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualState_CircleId",
                table: "ActualState",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualState_PersonId",
                table: "ActualState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualState_PersonId1",
                table: "ActualState",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActualState_ProjectId",
                table: "ActualState",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualState_TypeConsultorId",
                table: "ActualState",
                column: "TypeConsultorId");

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
                name: "IX_AspNetUsers_CircleId",
                table: "AspNetUsers",
                column: "CircleId");

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
                name: "IX_BankAccount_EnterpriseId",
                table: "BankAccount",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensive_BankAccountId",
                table: "Expensive",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensive_CaptureId",
                table: "Expensive",
                column: "CaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensive_DisbursementId",
                table: "Expensive",
                column: "DisbursementId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensive_PersonId",
                table: "Expensive",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CircleId",
                table: "Feedback",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PersonId",
                table: "Feedback",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ThemeId",
                table: "Feedback",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_HourDay_ActualStateId",
                table: "HourDay",
                column: "ActualStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_CircleId",
                table: "Learnings",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_PersonId",
                table: "Learnings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_ThemeId",
                table: "Learnings",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleLearn_LearningId",
                table: "PeopleLearn",
                column: "LearningId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleLearn_PersonId",
                table: "PeopleLearn",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_FeedbackId",
                table: "PersonFeedbacks",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_PersonId",
                table: "PersonFeedbacks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFeedbacks_PersonId1",
                table: "PersonFeedbacks",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLearnings_LearningId",
                table: "PersonLearnings",
                column: "LearningId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLearnings_PersonId",
                table: "PersonLearnings",
                column: "PersonId");
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
                name: "Expensive");

            migrationBuilder.DropTable(
                name: "HourDay");

            migrationBuilder.DropTable(
                name: "PeopleLearn");

            migrationBuilder.DropTable(
                name: "PersonFeedbacks");

            migrationBuilder.DropTable(
                name: "PersonLearnings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Capture");

            migrationBuilder.DropTable(
                name: "CostCenter");

            migrationBuilder.DropTable(
                name: "ActualState");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Learnings");

            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TypeConsultor");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Circle");
        }
    }
}
