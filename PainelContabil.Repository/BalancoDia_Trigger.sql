CREATE TRIGGER GeraBalancoDiario_Trigger
ON dbo.LancamentosFinanceiros
AFTER UPDATE, INSERT, DELETE
AS
	TRUNCATE TABLE dbo.BalancosDias;
BEGIN
	INSERT INTO dbo.BalancosDias(DataBalanco, ValorTotalCredito, ValorTotalDebito)
	SELECT CAST(DataLancamento AS DATE) 
		, COALESCE(SUM(case when [Tipo] = 'Cr�dito' then [Valor] end), 0) 
		, COALESCE(SUM(case when [Tipo] = 'D�bito' then [Valor] end), 0) 
	FROM dbo.LancamentosFinanceiros
	GROUP BY CAST(DataLancamento AS DATE);

	UPDATE dbo.BalancosDias
	SET Saldo = ValorTotalCredito - ValorTotalDebito;
END


--DROP TRIGGER IF EXISTS GeraBalancoDiario_Trigger
