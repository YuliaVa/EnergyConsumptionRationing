--Данный скрипт заполняет таблицы базы данных тестовым набором записей
use EnergyConsumptionRationing
SET NOCOUNT ON
DECLARE 
	@Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
	@i INT,
	@Position INT,
	@NumberProduction INT,
	@NumberRelease INT,
	@NumberConsumption INT,
	@NumberOrganization INT,
	@NumberExpense INT,
	@NumberString INT,
	@Number INT

SET NOCOUNT ON

--заполнение таблицы TypesProduction данными
DECLARE 
	@ProductionName nvarchar(30),
	@MeasureUnit nvarchar(15)
SET @NumberString = 100
-- ProductonID
SET @NumberProduction=1
	WHILE @NumberProduction<=@NumberString
	BEGIN
		SET @ProductionName = ''
		SET @MeasureUnit = ''
		SET @Number = 5+RAND()*25--данные от 5 до 30 символов
		SET @i=1
		WHILE @i<=@Number
		--Заполняем поле Наименование
		BEGIN
			SET @Position=RAND()*52
			SET @ProductionName = @ProductionName + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @MeasureUnit = @MeasureUnit + SUBSTRING(@Symbol, @Position, 1)
			SET @i = @i + 1
		END


		INSERT INTO TypesProduction(ProductionName, MeasureUnit)
		SELECT @ProductionName, @MeasureUnit
		
		SET @NumberProduction += 1
	END

--заполнение таблицы Organization данными
DECLARE
	@Symbol_ CHAR(62)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890',
	@Name_Organization nvarchar(30),
	@FormOwnership nvarchar(30),
	@Address nvarchar(30),
	@NameLeader nvarchar(30),
	@PhoneLeader INT,
	@NameEngineer nvarchar(30),
	@PhoneEngineer INT
SET @NumberString = 100
--OrganizationID
SET @NumberOrganization=1
	WHILE @NumberOrganization<=@NumberString
	BEGIN
		SET @Name_Organization=''
		SET @FormOwnership=''
		SET @Address=''
		SET @NameLeader = ''
		SET @NameEngineer = ''
		SET @Number = 5+RAND()*25
		SET @i=1
		WHILE @i<=@Number
		--Заполняем поля
		BEGIN
			SET @Position=RAND()*52
			SET @Name_Organization = @Name_Organization + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @FormOwnership = @FormOwnership + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*62
			SET @Address = @Address + SUBSTRING(@Symbol_, @Position, 1)
			SET @Position=RAND()*52
			SET @NameLeader = @NameLeader + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @NameEngineer = @NameEngineer + SUBSTRING(@Symbol, @Position, 1)
			SET @i = @i + 1
		END
		SET @PhoneLeader = 1 + RAND() * 99999998
		SET @PhoneEngineer = 1 + RAND() * 99999998

		INSERT INTO Organization(OrganizationName, FormOwnership, [Address], NameLeader, PhoneLeader, NameEngineer, PhoneEngineer)
		SELECT @Name_Organization, @FormOwnership, @Address, @NameLeader, @PhoneLeader, @NameEngineer, @PhoneEngineer

		SET @NumberOrganization+=1
	END

-- заполнение таблицы ReleaseProducts данными
DECLARE
	@TotalRelease INT,
	@Year INT,
	@Quarter INT,
	@ProductionID INT,
	@OrganizationID INT
SET @NumberString = 1000
--ReleaseID
SET @NumberRelease = 1
	WHILE @NumberRelease <= @NumberString
	BEGIN
		SET @TotalRelease = RAND()*99 + 1
		SET @Year = 1800 + RAND() * 217 -- заполняем поле год от 1800 до 2016
		SET @Quarter = 1 + RAND() * 4 -- заполняем поле квартал от 1 до 4
		SET @OrganizationID = 1 + RAND() * 100 --заполняем поле код организации (от 1 до 100)
		SET @ProductionID = 1 + RAND()*100-- заполняем поле код продукции (от 1 до 100)
		INSERT INTO ReleaseProducts(ProductionID, TotalRelease, [Year], [Quarter],OrganizationID)
		SELECT @ProductionID, @TotalRelease, @Year, @Quarter, @OrganizationID
	SET @NumberRelease += 1
	END

--заполнение таблицы ConsumedRelease данными
DECLARE
	@TotalConsumed INT,
	@_Year INT,
	@_Quarter INT,
	@Production_ID INT,
	@Organization_ID INT
SET @NumberString=1000
--ConsumptionID
SET @NumberConsumption=1
	WHILE @NumberConsumption<=@NumberString
	BEGIN
		SET @TotalConsumed = RAND()*99 + 1
		SET @_Year = 1800+RAND()*217
		SET @_Quarter = 1 + RAND()*4
		SET @Production_ID = 1+RAND() * 100
		SET @Organization_ID = 1 + RAND()* 100
		INSERT INTO ConsumedRelease(TotalConsumption, [Year], [Quarter], ProductionID, OrganizationID)
		SELECT @TotalConsumed, @_Year, @_Quarter, @Production_ID, @Organization_ID
	SET @NumberConsumption += 1
	END

--заполнение таблицы StandartExpanse данными
DECLARE
	@QuarterNorm INT,
	@ProductionID_ INT,
	@Year_ INT,
	@Quarter_ INT,
	@OrganizationID_ INT
SET @NumberString = 1000
--ExpenseID
SET @NumberExpense=1
	WHILE @NumberExpense<=@NumberString
	BEGIN
		SET @QuarterNorm = 1 + RAND()* 99
		SET @ProductionID_ = 1 + RAND() *100
		SET @Year_ = 1800 + RAND() * 217
		SET @Quarter_ = 1 + RAND() * 4
		SET @OrganizationID_ = 1 + RAND() * 100

		INSERT INTO StandartExpense(QuarterlyNormEnergyUnit, ProductionID, [Year], [Quarter], OrganizationID)
		SELECT @QuarterNorm, @ProductionID_, @Year_, @Quarter_, @OrganizationID_
	SET @NumberExpense+=1
	END
