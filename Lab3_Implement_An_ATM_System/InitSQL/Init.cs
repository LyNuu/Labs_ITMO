using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Itmo.ObjectOrientedProgramming.Lab5.InitSQL;

[Migration(1, "Initial")]
public class Init : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    
    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_password text not null ,
        user_balance text not null,
    );

    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;

    """;
}