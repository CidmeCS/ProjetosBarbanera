IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200410023202_Produto')
BEGIN
    CREATE TABLE [Produto] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200410023202_Produto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200410023202_Produto', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200412141745_Saldo')
BEGIN
    CREATE TABLE [saldos] (
        [Id] int NOT NULL IDENTITY,
        [Produto] nvarchar(max) NULL,
        [Descricao] nvarchar(max) NULL,
        [Unid] nvarchar(max) NULL,
        [Grupo] nvarchar(max) NULL,
        [Disponivel] float NOT NULL,
        [SaldoAtual] float NOT NULL,
        [SaldoUltFech] float NOT NULL,
        [Entradas] float NOT NULL,
        [Saidas] float NOT NULL,
        [PedCompras] float NOT NULL,
        [PedVendas] float NOT NULL,
        [ConsuPrevOs] float NOT NULL,
        [JaRequisOS] float NOT NULL,
        [ProdPrevOS] float NOT NULL,
        [ForaEstoque] float NOT NULL,
        [Transito] float NOT NULL,
        [DeTerceiros] float NOT NULL,
        [VendaConsign] float NOT NULL,
        [CompraEntrFutura] float NOT NULL,
        [VendaEntrFutura] float NOT NULL,
        [CompraConsig] float NOT NULL,
        [AguardandoCQ] float NOT NULL,
        [EstqMínimo] float NOT NULL,
        [EstqMáximo] float NOT NULL,
        [ReservaDeVendas] float NOT NULL,
        [Prateleira] nvarchar(max) NULL,
        [SaldoPedidoDataEntregaExcedida] float NOT NULL,
        [PrevFabric] float NOT NULL,
        [DiassemMovimento] float NOT NULL,
        CONSTRAINT [PK_saldos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200412141745_Saldo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200412141745_Saldo', N'3.1.1');
END;

GO

