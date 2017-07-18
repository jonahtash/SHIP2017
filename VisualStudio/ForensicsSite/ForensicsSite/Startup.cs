using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ForensicsSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                string requestType = context.Request.ContentType;
                string path = context.Request.Path.ToUriComponent();
                if (path.Equals("/"))
                {
                    context.Response.Redirect("index.html");
                    return;
                }
                string fileRequested = string.Join("\\", context.Request.Path.ToUriComponent().Split('/'));
                context.Response.Clear();
                if (fileRequested.Equals("search")){
                    fileRequested = "index.html";
                }
				if (fileRequested.Contains('.')&&fileRequested.Split('.')[1] == "html")
				{
					context.Response.ContentType = "text/html";
				}
                if (fileRequested.Contains('.') && fileRequested.Split('.')[1] == "php")
                {
                    context.Response.ContentType = "text/php";
                }
                if (fileRequested.Contains('.') && fileRequested.Split('.')[1] == "css")
				{
					context.Response.ContentType = "text/css";
				}
				byte[] file = FileToByteArray(".\\wwwroot\\" + fileRequested);
				context.Response.Body.Write(file, 0, file.Length);
				await context.Response.WriteAsync("");
            });
        }
    }
}
