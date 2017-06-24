﻿//using System.Threading.Tasks;
//using DotNetCore.CAP.Infrastructure;
//using DotNetCore.CAP.Store;
//using Microsoft.AspNetCore.Builder.Internal;
//using Microsoft.AspNetCore.Testing.xunit;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;

//namespace DotNetCore.CAP.EntityFrameworkCore.Test
//{
//    public class DefaultPocoTest : IClassFixture<ScratchDatabaseFixture>
//    {
//        private readonly ApplicationBuilder _builder;

//        public DefaultPocoTest(ScratchDatabaseFixture fixture) {
//            var services = new ServiceCollection();

//            services
//                .AddDbContext<ConsistencyDbContext>(o => o.UseSqlServer(fixture.ConnectionString))
//                .AddConsistency()
//                .AddEntityFrameworkStores<ConsistencyDbContext>();

//            services.AddLogging();

//            var provider = services.BuildServiceProvider();
//            _builder = new ApplicationBuilder(provider);

//            using (var scoped = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
//            using (var db = scoped.ServiceProvider.GetRequiredService<ConsistencyDbContext>()) {
//                db.Database.EnsureCreated();
//            }
//        }

//        [ConditionalFact]
//        [FrameworkSkipCondition(RuntimeFrameworks.Mono)]
//        [OSSkipCondition(OperatingSystems.Linux)]
//        [OSSkipCondition(OperatingSystems.MacOSX)]
//        public async Task EnsureStartupUsageWorks() {
//            var messageStore = _builder.ApplicationServices.GetRequiredService<IConsistencyMessageStore>();
//            var messageManager = _builder.ApplicationServices.GetRequiredService<IConsistencyMessageStore >();

//            Assert.NotNull(messageStore);
//            Assert.NotNull(messageManager);

//            var user = new ConsistencyMessage();

//            var operateResult = await messageManager.CreateAsync(user);
//            Assert.True(operateResult.Succeeded);

//            operateResult = await messageManager.DeleteAsync(user);
//            Assert.True(operateResult.Succeeded);
//        }
//    }
//}