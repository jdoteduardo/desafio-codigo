using AutoMapper;
using Desafio.API.ViewModels;
using Desafio.Domain.Entities;
using Desafio.Infra.Context;
using Desafio.Infra.Interfaces;
using Desafio.Infra.Repositories;
using Desafio.Service.DTO;
using Desafio.Service.Interfaces;
using Desafio.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region IOC
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cidade, CidadeDTO>().ReverseMap();
                cfg.CreateMap<Pessoa, PessoaDTO>().ReverseMap();
                cfg.CreateMap<CriarCidadeViewModel, CidadeDTO>().ReverseMap();
                cfg.CreateMap<CriarPessoaViewModel, PessoaDTO>().ReverseMap();
                cfg.CreateMap<UpdateCidadeViewModel, CidadeDTO>().ReverseMap();
                cfg.CreateMap<UpdatePessoaViewModel, PessoaDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddSingleton(d => Configuration);
            services.AddDbContext<DesafioContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Cadastro"]), ServiceLifetime.Transient);
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
