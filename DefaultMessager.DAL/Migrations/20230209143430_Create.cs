using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    pkaccountid = table.Column<Guid>(name: "pk_account_id", type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    login = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: false),
                    role = table.Column<short>(type: "smallint", nullable: false),
                    createdate = table.Column<DateTime>(name: "create_date", type: "timestamp with time zone", nullable: false),
                    statusaccount = table.Column<short>(name: "status_account", type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.pkaccountid);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions_users",
                columns: table => new
                {
                    pkdescriptionid = table.Column<Guid>(name: "pk_description_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    surname = table.Column<string>(type: "character varying", nullable: true),
                    patronymic = table.Column<string>(type: "character varying", nullable: true),
                    describe = table.Column<string>(type: "character varying", nullable: true),
                    descriptionstatus = table.Column<string>(name: "description_status", type: "character varying", nullable: true),
                    pathavatar = table.Column<string>(name: "path_avatar", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions_users", x => x.pkdescriptionid);
                    table.ForeignKey(
                        name: "FK_Descriptions_users_users_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image_albums",
                columns: table => new
                {
                    pkimagealbumid = table.Column<Guid>(name: "pk_image_album_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false),
                    pathpictures = table.Column<string[]>(name: "path_pictures", type: "text[]", nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image_albums", x => x.pkimagealbumid);
                    table.ForeignKey(
                        name: "FK_Image_albums_users_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    pkmessageid = table.Column<Guid>(name: "pk_message_id", type: "uuid", nullable: false),
                    fkrecieveid = table.Column<Guid>(name: "fk_recieve_id", type: "uuid", nullable: false),
                    fksenderid = table.Column<Guid>(name: "fk_sender_id", type: "uuid", nullable: false),
                    pathpictures = table.Column<string[]>(name: "path_pictures", type: "text[]", nullable: true),
                    pathaudios = table.Column<string[]>(name: "path_audios", type: "text[]", nullable: true),
                    senddatetime = table.Column<DateTime>(name: "send_date_time", type: "timestamp with time zone", nullable: false),
                    messagestatus = table.Column<short>(name: "message_status", type: "smallint", nullable: false),
                    messagetextcontent = table.Column<string>(name: "message_text_content", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.pkmessageid);
                    table.ForeignKey(
                        name: "FK_Messages_users_fk_recieve_id",
                        column: x => x.fkrecieveid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_users_fk_sender_id",
                        column: x => x.fksenderid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    pkpostid = table.Column<Guid>(name: "pk_post_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false),
                    pathpictures = table.Column<string[]>(name: "path_pictures", type: "text[]", nullable: true),
                    posttextcontent = table.Column<string>(name: "post_text_content", type: "character varying", nullable: true),
                    title = table.Column<string>(type: "character varying", nullable: true),
                    pathaudios = table.Column<string[]>(name: "path_audios", type: "text[]", nullable: true),
                    senddatetime = table.Column<DateTime>(name: "send_date_time", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.pkpostid);
                    table.ForeignKey(
                        name: "FK_Posts_users_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    pkcommentid = table.Column<Guid>(name: "pk_comment_id", type: "uuid", nullable: false),
                    fkpostid = table.Column<Guid>(name: "fk_post_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false),
                    commenttextcontent = table.Column<string>(name: "comment_text_content", type: "character varying", nullable: true),
                    datepublicate = table.Column<DateTime>(name: "date_publicate", type: "timestamp with time zone", nullable: false),
                    commentstatus = table.Column<short>(name: "comment_status", type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.pkcommentid);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_fk_post_id",
                        column: x => x.fkpostid,
                        principalTable: "Posts",
                        principalColumn: "pk_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_users_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    pklikeid = table.Column<Guid>(name: "pk_like_id", type: "uuid", nullable: false),
                    fkpostid = table.Column<Guid>(name: "fk_post_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.pklikeid);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_fk_post_id",
                        column: x => x.fkpostid,
                        principalTable: "Posts",
                        principalColumn: "pk_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_users_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "users",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_account_id",
                table: "Comments",
                column: "fk_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_post_id",
                table: "Comments",
                column: "fk_post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_users_fk_account_id",
                table: "Descriptions_users",
                column: "fk_account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_albums_fk_account_id",
                table: "Image_albums",
                column: "fk_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_fk_account_id",
                table: "Likes",
                column: "fk_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_fk_post_id",
                table: "Likes",
                column: "fk_post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_fk_recieve_id",
                table: "Messages",
                column: "fk_recieve_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_fk_sender_id",
                table: "Messages",
                column: "fk_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_fk_account_id",
                table: "Posts",
                column: "fk_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Descriptions_users");

            migrationBuilder.DropTable(
                name: "Image_albums");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
