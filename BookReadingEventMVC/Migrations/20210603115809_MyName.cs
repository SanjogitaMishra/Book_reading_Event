using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReadingEventMVC.Migrations
{
    public partial class MyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventInviteds_Events_EventsId",
                table: "EventInviteds");

            migrationBuilder.DropIndex(
                name: "IX_EventInviteds_EventsId",
                table: "EventInviteds");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventsId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "EventsId1",
                table: "EventInviteds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventsId1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventInviteds_EventsId1",
                table: "EventInviteds",
                column: "EventsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventsId1",
                table: "Comments",
                column: "EventsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventsId1",
                table: "Comments",
                column: "EventsId1",
                principalTable: "Events",
                principalColumn: "EventsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventInviteds_Events_EventsId1",
                table: "EventInviteds",
                column: "EventsId1",
                principalTable: "Events",
                principalColumn: "EventsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventsId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventInviteds_Events_EventsId1",
                table: "EventInviteds");

            migrationBuilder.DropIndex(
                name: "IX_EventInviteds_EventsId1",
                table: "EventInviteds");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventsId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EventsId1",
                table: "EventInviteds");

            migrationBuilder.DropColumn(
                name: "EventsId1",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_EventInviteds_EventsId",
                table: "EventInviteds",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventsId",
                table: "Comments",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventsId",
                table: "Comments",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "EventsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventInviteds_Events_EventsId",
                table: "EventInviteds",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "EventsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
