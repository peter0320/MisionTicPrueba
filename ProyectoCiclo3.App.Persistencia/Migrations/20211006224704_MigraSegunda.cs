using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCiclo3.App.Persistencia.Migrations
{
    public partial class MigraSegunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encomiendas");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Encomiendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    peso = table.Column<int>(type: "int", nullable: false),
                    presentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomiendas", x => x.id);
                });
        }
    }
}
