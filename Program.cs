using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


// Instalar o gerenciador de pacotes EF na máquina
// dotnet tool install --global dotnet-ef

// Baixar Pacote SQL Server
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Baixar pacote de escrita de códigos do EF
// dotnet add package Microsoft.EntityFrameworkCore.Design

// Dar um restore na aplicação para ler e aplicar os pacotes instalados
// dotnet restore

// Testar se o EF está ok
// dotnet ef

// Criar os Models à partir da sua base de Dados
// -o = criar o diretorio caso não exista
// -d = Incluir as DataNotations do banco
// dotnet ef dbcontext scaffold "Server=DESKTOP-XVGT587\SQLEXPRESS;Database=teste;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -d

// Criar nosso primeiro controller, neste caso o controller de Endereço


// Adicionar pacote para ler a árvore de objetos no retorno
// dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

// Adicionar dentro de Startup.cs a configuração de serialização dos controllers:
// services.AddControllersWithViews().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

namespace EFDatabaseFirts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
