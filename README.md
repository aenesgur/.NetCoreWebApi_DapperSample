# .NetCoreWebApi_DapperSample
Its a .Net Core 3.1 Web Api application which using Dapper Micro Orm

### Procedures

```sh
    Create PROC sp_ProductSave
    @Name NVARCHAR(MAX),
    @Price decimal(18,0),
    @Origin NVARCHAR(MAX) = NULL

    As
    Begin

    Insert Into PRoduct (Name,Price,Origin)
    Values(@Name,@Price,@Origin)

    END
```
```sh
    CREATE PROC sp_ProductDelete
    @Id INT

    As
    Begin

    Delete from Product Where Id=@Id
    END
```
