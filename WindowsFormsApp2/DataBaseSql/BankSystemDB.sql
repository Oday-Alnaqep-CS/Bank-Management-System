-- Bank System Database
-- Requires SQL Server 2016 or later.
-- SQL Server chooses the physical MDF/LDF file locations automatically.

USE [master]
GO

CREATE DATABASE [BankSystemDB]
GO

ALTER DATABASE [BankSystemDB]
SET COMPATIBILITY_LEVEL = 130
GO

USE [BankSystemDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](30) NOT NULL,
	[PersonID] [int] NOT NULL,
	[DepartmentID] [int] NULL,
	[BranchID] [int] NULL,
	[JobTitle] [nvarchar](50) NULL,
	[HireDate] [date] NULL,
	[Salary] [decimal](18, 2) NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[NationalID] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[ImagePath] [nvarchar](300) NULL,
	[Gender] [tinyint] NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](200) NULL,
	[CityID] [int] NULL,
	[PersonType] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](20) NULL,
	[CityID] [int] NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCredentials](
	[UserID] [nvarchar](30) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](256) NOT NULL,
	[PasswordSalt] [nvarchar](128) NULL,
	[FailedLoginAttempts] [tinyint] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[LastLoginDate] [datetime] NULL,
 CONSTRAINT [PK_UserCredentials] PRIMARY KEY CLUSTERED
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[RoleID] [int] NOT NULL,
	[PermissionID] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED
(
	[RoleID] ASC,
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserID] [nvarchar](30) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_UserPermissions] AS
SELECT
    U.UserID AS [User ID],
    UC.Username AS [User Name],
    (P.FirstName + ' ' + P.LastName) AS [Employee Name],
    U.JobTitle AS [Job Title],
    D.DepartmentName AS [Department Name],
    B.BranchName AS [Branch Name],
    R.RoleName AS [Role Name],
    Perm.PermissionName AS [Permission Name],
    Perm.Description AS [Permission Description],
    CASE U.Status
        WHEN 1 THEN 'Active'
        WHEN 2 THEN 'Inactive'
        ELSE 'Unknown'
    END AS [Account Status],
    UC.IsLocked AS [Is Locked],
    UC.LastLoginDate AS [Last Login Date]
FROM Users U
INNER JOIN UserCredentials UC ON U.UserID = UC.UserID
INNER JOIN Persons P ON U.PersonID = P.PersonID
INNER JOIN Departments D ON U.DepartmentID = D.DepartmentID
INNER JOIN Branches B ON U.BranchID = B.BranchID
LEFT JOIN UserRoles UR ON U.UserID = UR.UserID
LEFT JOIN Roles R ON UR.RoleID = R.RoleID
LEFT JOIN RolePermissions RP ON R.RoleID = RP.RoleID
LEFT JOIN Permissions Perm ON RP.PermissionID = Perm.PermissionID;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [nvarchar](20) NOT NULL,
	[IBAN] [nvarchar](34) NOT NULL,
	[ClientID] [int] NOT NULL,
	[AccountTypeID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CardID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[CardNumber] [nvarchar](16) NOT NULL,
	[CardType] [tinyint] NOT NULL,
	[PIN_Hash] [nvarchar](256) NOT NULL,
	[CVV_Hash] [nvarchar](256) NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[DailyLimit] [decimal](18, 2) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[ClientType] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Cards] AS
SELECT
    C.CardID AS [Card ID],
    C.CardNumber AS [Card Number],
    CASE C.CardType
        WHEN 1 THEN 'Debit Card'
        WHEN 2 THEN 'Credit Card'
        ELSE 'Unknown'
    END AS [Card Type Name],
    A.AccountNumber AS [Account Number],
    (P.FirstName + ' ' + P.LastName) AS [Client Name],
    P.Phone AS [Client Phone],
    C.DailyLimit AS [Daily Limit],
    C.ExpiryDate AS [Expiry Date],
    DATEDIFF(day, GETDATE(), C.ExpiryDate) AS [Days Until Expiry],
    CASE
        WHEN C.ExpiryDate < GETDATE() THEN 'Expired'
        WHEN DATEDIFF(day, GETDATE(), C.ExpiryDate) <= 30 THEN 'Expiring Soon'
        ELSE 'Valid'
    END AS [Expiry Status],
    CASE C.Status
        WHEN 1 THEN 'Active'
        WHEN 2 THEN 'Suspended'
        WHEN 3 THEN 'Cancelled'
        ELSE 'Unknown'
    END AS [Card Status]
FROM Cards C
INNER JOIN Accounts A ON C.AccountID = A.AccountID
INNER JOIN Clients Cl ON A.ClientID = Cl.ClientID
INNER JOIN Persons P ON Cl.PersonID = P.PersonID;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[FromAccountID] [int] NULL,
	[ToAccountID] [int] NULL,
	[TransactionTypeID] [nvarchar](30) NULL,
	[CurrencyID] [int] NOT NULL,
	[PerformedByClientID] [int] NULL,
	[ExecutedByUserID] [nvarchar](30) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Status] [tinyint] NOT NULL,
	[FromClientName] [nvarchar](100) NULL,
	[ToClientName] [nvarchar](100) NULL,
	[AmountAfter] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [nvarchar](10) NOT NULL,
	[CurrencyName] [nvarchar](50) NOT NULL,
	[CurrencySymbol] [nvarchar](10) NOT NULL,
	[ExchangeRate] [decimal](18, 4) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[FlagPath] [nvarchar](250) NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Branches] AS
SELECT
    B.BranchID AS [Branch ID],
    B.BranchName AS [Branch Name],
    C.CityName AS [City Name],
    COUNT(DISTINCT A.AccountID) AS [Total Accounts],
    ISNULL(SUM(A.Balance * Curr.ExchangeRate), 0) AS [Total Deposits In Base Currency],
    COUNT(DISTINCT T.TransactionID) AS [Total Transactions Executed],
    ISNULL(SUM(CASE WHEN T.TransactionTypeID = 1 THEN T.Amount ELSE 0 END), 0) AS [Total Deposits Amount],
    ISNULL(SUM(CASE WHEN T.TransactionTypeID = 2 THEN T.Amount ELSE 0 END), 0) AS [Total Withdrawals Amount]
FROM Branches B
INNER JOIN Cities C ON B.CityID = C.CityID
LEFT JOIN Accounts A ON B.BranchID = A.BranchID
LEFT JOIN Currencies Curr ON A.CurrencyID = Curr.CurrencyID
LEFT JOIN Transactions T ON A.AccountID = T.FromAccountID OR A.AccountID = T.ToAccountID
GROUP BY
    B.BranchID,
    B.BranchName,
    C.CityName;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_User] AS
SELECT
    U.UserID AS [User ID],
    U.PersonID AS [Person ID],
    U.DepartmentID AS [Department ID],
    U.BranchID AS [Branch ID],
    U.JobTitle AS [Job Title],
    U.HireDate AS [Hire Date],
    U.Salary,
    CASE U.Status
        WHEN 1 THEN 'Active'
        WHEN 2 THEN 'Inactive'
        ELSE 'Unknown'
    END AS [Account Status],
    UC.Username
FROM Users U
INNER JOIN UserCredentials UC ON U.UserID = UC.UserID;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loans](
	[LoanID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[LoanAmount] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Loans] PRIMARY KEY CLUSTERED
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanInstallments](
	[LoanInstallmentID] [int] IDENTITY(1,1) NOT NULL,
	[LoanID] [int] NOT NULL,
	[DueDate] [date] NOT NULL,
	[AmountDue] [decimal](18, 2) NOT NULL,
	[PaidDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_LoanInstallments] PRIMARY KEY CLUSTERED
(
	[LoanInstallmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Loans] AS
SELECT
    L.LoanID,
    L.ClientID AS [Customer ID],
    (P.FirstName + ' ' + P.LastName) AS [Client Name],
    P.Phone AS [Customer Phone],
    L.LoanAmount AS [Original Loan Amount],
    L.TotalAmount AS [Total Loan With Interest],
    ISNULL(SUM(CASE WHEN LI.Status = 2 THEN LI.AmountDue ELSE 0 END), 0) AS [Total Amount Paid],
    (L.TotalAmount - ISNULL(SUM(CASE WHEN LI.Status = 2 THEN LI.AmountDue ELSE 0 END), 0)) AS [Remaining Balance],
    COUNT(LI.LoanInstallmentID) AS [Total Installments Count],
    SUM(CASE WHEN LI.Status = 2 THEN 1 ELSE 0 END) AS [Paid Installments Count],
    SUM(CASE WHEN LI.Status = 1 THEN 1 ELSE 0 END) AS [Pending Installments Count],
    L.StartDate AS [Start Date],
    L.EndDate AS [End Date],
    CASE L.Status
        WHEN 1 THEN 'Active'
        WHEN 2 THEN 'Paid'
        WHEN 3 THEN 'Defaulted'
        ELSE 'Unknown'
    END AS [Loan Status]
FROM Loans L
INNER JOIN Clients Cl ON L.ClientID = Cl.ClientID
INNER JOIN Persons P ON Cl.PersonID = P.PersonID
LEFT JOIN LoanInstallments LI ON L.LoanID = LI.LoanID
GROUP BY
    L.LoanID,
    L.ClientID,
    P.FirstName,
    P.LastName,
    P.Phone,
    L.LoanAmount,
    L.TotalAmount,
    L.StartDate,
    L.EndDate,
    L.Status;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[TransactionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Transactions] AS
SELECT
    T.TransactionID AS [Transaction ID] ,
    T.TransactionDate AS [Transaction Date],
    TT.TypeName AS [Transaction Type],
    C.CurrencyCode AS [Currency Code],
    T.Amount,
    FromAcc.AccountNumber AS [From Account Number],
    ISNULL(T.FromClientName, (PFrom.FirstName + ' ' + PFrom.LastName)) AS [From Client Name],
    ToAcc.AccountNumber AS [To Account Number],
    ISNULL(T.ToClientName, (PTo.FirstName + ' ' + PTo.LastName)) AS [To Client Name],
    (PEmp.FirstName + ' ' + PEmp.LastName) AS [Executed By Employee],
    T.Description,
    CASE T.Status
        WHEN 1 THEN 'Success'
        WHEN 2 THEN 'Cancelled'
        WHEN 3 THEN 'Pending'
        ELSE 'Failed'
    END AS [Transaction Status]
FROM Transactions T
INNER JOIN TransactionType TT ON T.TransactionTypeID = TT.TransactionTypeID
INNER JOIN Currencies C ON T.CurrencyID = C.CurrencyID
LEFT JOIN Accounts FromAcc ON T.FromAccountID = FromAcc.AccountID
LEFT JOIN Clients ClFrom ON FromAcc.ClientID = ClFrom.ClientID
LEFT JOIN Persons PFrom ON ClFrom.PersonID = PFrom.PersonID
LEFT JOIN Accounts ToAcc ON T.ToAccountID = ToAcc.AccountID
LEFT JOIN Clients ClTo ON ToAcc.ClientID = ClTo.ClientID
LEFT JOIN Persons PTo ON ClTo.PersonID = PTo.PersonID
LEFT JOIN Users U ON T.ExecutedByUserID = U.UserID
LEFT JOIN Persons PEmp ON U.PersonID = PEmp.PersonID;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[AccountTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
	[InterestRate] [decimal](5, 2) NOT NULL,
	[MinimumBalance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Accounts] AS
SELECT
    A.AccountID AS [Account ID],
    A.AccountNumber AS [Account Number],
    A.IBAN,
    P.NationalID AS [National ID],
    (P.FirstName + ' ' + P.LastName) AS [Customer Name],
    P.Phone AS [Customer Phone],
    P.Email AS [Customer Email],
    AT.TypeName AS [Account Type],
    C.CurrencyCode AS [Currency Code],
    C.CurrencySymbol AS [Currency Symbol],
    A.Balance,
    B.BranchName AS [Branch Name],
    CASE A.Status
        WHEN 1 THEN 'Active'
        WHEN 2 THEN 'Frozen'
        WHEN 3 THEN 'Dormant'
        ELSE 'Unknown'
    END AS [Account Status],
    A.CreatedDate AS [Created Date]
FROM Accounts A
INNER JOIN Clients Cl ON A.ClientID = Cl.ClientID
INNER JOIN Persons P ON Cl.PersonID = P.PersonID
INNER JOIN AccountTypes AT ON A.AccountTypeID = AT.AccountTypeID
INNER JOIN Currencies C ON A.CurrencyID = C.CurrencyID
INNER JOIN Branches B ON A.BranchID = B.BranchID;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[CountryCode] [nvarchar](10) NOT NULL,
	[PhoneCode] [nvarchar](10) NOT NULL,
	[FlagPath] [nvarchar](250) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyRateHistory](
	[RateHistoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[OldBuyRate] [decimal](18, 6) NOT NULL,
	[OldSellRate] [decimal](18, 6) NOT NULL,
	[NewBuyRate] [decimal](18, 6) NOT NULL,
	[NewSellRate] [decimal](18, 6) NOT NULL,
	[ChangedByUserID] [nvarchar](50) NULL,
	[ChangedDate] [datetime2](7) NOT NULL,
	[ChangeReason] [nvarchar](250) NULL,
 CONSTRAINT [PK_CurrencyRateHistory] PRIMARY KEY CLUSTERED
(
	[RateHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyBranchSummary](
	[SummaryID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[OpeningBalance] [decimal](18, 2) NOT NULL,
	[TotalTax] [decimal](18, 2) NOT NULL,
	[ClosingBalance] [decimal](18, 2) NOT NULL,
	[TotalTransactionsCount] [int] NOT NULL,
	[LatestUpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DailyBranchSummary] PRIMARY KEY CLUSTERED
(
	[SummaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanGuarantors](
	[GuarantorID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[LoanID] [int] NOT NULL,
	[GuarantorType] [nvarchar](50) NULL,
	[GuaranteedDate] [date] NOT NULL,
 CONSTRAINT [PK_LoanGuarantors] PRIMARY KEY CLUSTERED
(
	[GuarantorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[SentDate] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[UserID] [nvarchar](30) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON

INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (1, N'1010-001-YER', N'YE99BANK1010001001YER', 1, 1, 2, 1, CAST(2000000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (2, N'1010-001-USD', N'YE99BANK1010001001USD', 1, 2, 2, 2, CAST(14500.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (3, N'2020-002-USD', N'YE99BANK2020002002USD', 2, 3, 1, 2, CAST(120000.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (4, N'2020-002-SAR', N'YE99BANK2020002002SAR', 2, 3, 1, 3, CAST(450000.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (5, N'3030-003-YER', N'YE99BANK3030003003YER', 3, 1, 3, 1, CAST(2139000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (6, N'4040-004-USD', N'YE99BANK4040004004USD', 4, 1, 1, 2, CAST(3200.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (7, N'5050-005-YER', N'YE99BANK5050005005YER', 5, 5, 2, 1, CAST(92000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (8, N'6060-006-EUR', N'YE99BANK6060006006EUR', 6, 2, 4, 4, CAST(9800.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (9, N'7070-007-USD', N'YE99BANK7070007007USD', 7, 3, 5, 2, CAST(67000.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (10, N'8080-008-YER', N'YE99BANK8080008008YER', 8, 1, 1, 1, CAST(1050000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (11, N'9090-009-SAR', N'YE99BANK9090009009SAR', 9, 2, 2, 3, CAST(22000.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (12, N'1010-010-SAR', N'YE99BANK1010010010SAR', 10, 1, 3, 3, CAST(75000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (13, N'1111-011-AED', N'YE99BANK1111011011AED', 11, 2, 4, 5, CAST(34000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (14, N'1212-012-USD', N'YE99BANK1212012012USD', 2, 1, 1, 2, CAST(18500.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (15, N'1313-013-YER', N'YE99BANK1313013013YER', 3, 3, 2, 1, CAST(920000.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (16, N'1414-014-GBP', N'YE99BANK1414014014GBP', 4, 2, 3, 6, CAST(12000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (17, N'1515-015-KWD', N'YE99BANK1515015015KWD', 5, 1, 4, 7, CAST(8350.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (18, N'1616-016-QAR', N'YE99BANK1616016016QAR', 6, 3, 5, 8, CAST(62000.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (19, N'1717-017-OMR', N'YE99BANK1717017017OMR', 7, 1, 1, 9, CAST(16000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (20, N'1818-018-BHD', N'YE99BANK1818018018BHD', 8, 2, 2, 10, CAST(9500.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (21, N'1919-019-JOD', N'YE99BANK1919019019JOD', 9, 3, 3, 11, CAST(28000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (22, N'2020-020-CAD', N'YE99BANK2020020020CAD', 10, 1, 4, 13, CAST(38000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (23, N'2121-021-AUD', N'YE99BANK2121021021AUD', 11, 2, 5, 14, CAST(33000.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (24, N'2222-022-CHF', N'YE99BANK2222022022CHF', 1, 3, 1, 15, CAST(19000.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (25, N'2323-023-CNY', N'YE99BANK2323023023CNY', 2, 1, 2, 17, CAST(210000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (26, N'2424-024-INR', N'YE99BANK2424024024INR', 3, 2, 3, 18, CAST(1000000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (27, N'2525-025-TRY', N'YE99BANK2525025025TRY', 4, 3, 4, 19, CAST(145000.00 AS Decimal(18, 2)), 2, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (28, N'2626-026-MYR', N'YE99BANK2626026026MYR', 5, 1, 5, 20, CAST(88000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (29, N'2727-027-SGD', N'YE99BANK2727027027SGD', 6, 2, 1, 21, CAST(42000.00 AS Decimal(18, 2)), 3, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (30, N'2828-028-USD', N'YE99BANK2828028028USD', 7, 1, 2, 2, CAST(53000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:58:50.190' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (1003, N'ACC-69136752', N'YE93BANK4369136752', 45, 2, 3, 1, CAST(2500.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-26T01:37:16.930' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [AccountNumber], [IBAN], [ClientID], [AccountTypeID], [BranchID], [CurrencyID], [Balance], [Status], [CreatedDate]) VALUES (1004, N'ACC-25537274', N'YE93BANK3325537274', 46, 1, 2, 1, CAST(2500.00 AS Decimal(18, 2)), 1, CAST(N'2026-11-16T22:52:12.570' AS DateTime))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON

INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (1, N'Checking Account', CAST(0.00 AS Decimal(5, 2)), CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (2, N'Savings Account', CAST(3.25 AS Decimal(5, 2)), CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (3, N'Corporate Account', CAST(0.00 AS Decimal(5, 2)), CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (4, N'Weekly Account', CAST(4.50 AS Decimal(5, 2)), CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (5, N'Payroll Acccount', CAST(0.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (6, N'Checking Account - Individual', CAST(0.00 AS Decimal(5, 2)), CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (7, N'Savings Account - Investment', CAST(3.25 AS Decimal(5, 2)), CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (8, N'Corporate / Commercial Account', CAST(0.00 AS Decimal(5, 2)), CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (9, N'Weekly Deposit Account', CAST(4.50 AS Decimal(5, 2)), CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[AccountTypes] ([AccountTypeID], [TypeName], [InterestRate], [MinimumBalance]) VALUES (10, N'Payroll Account', CAST(0.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Branches] ON

INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (1, N'Main Branch - Al-Zubairi', N'Al-Zubairi St - Hadda Intersection', N'01200100', 1)
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (2, N'Taiz Branch - Jamal St', N'Jamal St - Opposite Ring Road', N'04210200', 2)
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (3, N'Aden Branch - Crater', N'Arwa St - Crater', N'02220300', 3)
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (4, N'Ibb Branch - Al-Odayn St', N'Main Al-Odayn St', N'04410400', 5)
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (5, N'Mukalla Branch - Al-Sharij', N'Al-Sharij Area - Main Street', N'05300500', 6)
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Address], [Phone], [CityID]) VALUES (6, N'Riyadh Branch - Al-Olaya', N'King Fahd Road - Al-Olaya District', N'+96611200', 7)
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[Cards] ON

INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (1, 1, N'4532010011112222', 1, N'p_hash_1', N'c_hash_1', CAST(N'2028-05-31' AS Date), CAST(500000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (2, 2, N'4532010011113333', 2, N'p_hash_2', N'c_hash_2', CAST(N'2029-01-31' AS Date), CAST(3000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (3, 3, N'5412750022224444', 2, N'p_hash_3', N'c_hash_3', CAST(N'2027-11-30' AS Date), CAST(10000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (4, 4, N'5412750022225556', 1, N'p_hash_4', N'c_hash_4', CAST(N'2028-03-31' AS Date), CAST(15000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (5, 5, N'4532010033335555', 1, N'p_hash_5', N'c_hash_5', CAST(N'2028-08-31' AS Date), CAST(200000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (6, 6, N'5412750044446667', 2, N'p_hash_6', N'c_hash_6', CAST(N'2029-06-30' AS Date), CAST(5000.00 AS Decimal(18, 2)), 0, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (7, 7, N'4532010055557777', 1, N'p_hash_7', N'c_hash_7', CAST(N'2026-12-31' AS Date), CAST(300000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (8, 8, N'4532010066668888', 1, N'p_hash_8', N'c_hash_8', CAST(N'2030-02-28' AS Date), CAST(250000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (9, 9, N'5412750077779999', 2, N'p_hash_9', N'c_hash_9', CAST(N'2027-09-30' AS Date), CAST(8000.00 AS Decimal(18, 2)), 0, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (10, 10, N'4532010088880000', 1, N'p_hash_10', N'c_hash_10', CAST(N'2029-10-31' AS Date), CAST(150000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (11, 11, N'5412750099991111', 2, N'p_hash_11', N'c_hash_11', CAST(N'2028-12-31' AS Date), CAST(12000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (12, 1, N'4532010011114444', 2, N'p_hash_12', N'c_hash_12', CAST(N'2028-07-31' AS Date), CAST(4000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (13, 2, N'5412750022225555', 1, N'p_hash_13', N'c_hash_13', CAST(N'2029-04-30' AS Date), CAST(100000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (14, 3, N'4532010033336666', 1, N'p_hash_14', N'c_hash_14', CAST(N'2027-10-31' AS Date), CAST(150000.00 AS Decimal(18, 2)), 0, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (15, 4, N'4532010044447777', 2, N'p_hash_15', N'c_hash_15', CAST(N'2030-01-31' AS Date), CAST(6000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (16, 5, N'5412750055558888', 2, N'p_hash_16', N'c_hash_16', CAST(N'2028-09-30' AS Date), CAST(9000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (17, 6, N'4532010066669999', 1, N'p_hash_17', N'c_hash_17', CAST(N'2029-05-31' AS Date), CAST(180000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (18, 7, N'5412750077770000', 1, N'p_hash_18', N'c_hash_18', CAST(N'2026-11-30' AS Date), CAST(220000.00 AS Decimal(18, 2)), 0, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (19, 8, N'4532010088881111', 2, N'p_hash_19', N'c_hash_19', CAST(N'2030-03-31' AS Date), CAST(7000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (20, 9, N'5412750099992222', 1, N'p_hash_20', N'c_hash_20', CAST(N'2027-08-31' AS Date), CAST(130000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (21, 10, N'4532010000003333', 2, N'p_hash_21', N'c_hash_21', CAST(N'2028-06-30' AS Date), CAST(5500.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (22, 11, N'5412750011114444', 1, N'p_hash_22', N'c_hash_22', CAST(N'2029-02-28' AS Date), CAST(190000.00 AS Decimal(18, 2)), 0, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (23, 1, N'5412750022226666', 2, N'p_hash_23', N'c_hash_23', CAST(N'2030-08-31' AS Date), CAST(8500.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (24, 2, N'4532010033337777', 1, N'p_hash_24', N'c_hash_24', CAST(N'2027-12-31' AS Date), CAST(210000.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
INSERT [dbo].[Cards] ([CardID], [AccountID], [CardNumber], [CardType], [PIN_Hash], [CVV_Hash], [ExpiryDate], [DailyLimit], [Status], [CreatedDate]) VALUES (25, 3, N'5412750044448888', 2, N'p_hash_25', N'c_hash_25', CAST(N'2028-04-30' AS Date), CAST(6500.00 AS Decimal(18, 2)), 1, CAST(N'2026-09-24T17:59:22.497' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON

INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (1, N'Sanaa', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (2, N'Taiz', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (3, N'Aden', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (4, N'Hodeidah', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (5, N'Ibb', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (6, N'Mukalla', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (7, N'Al-Houban', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (8, N'Riyadh', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (9, N'Jeddah', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (10, N'Mecca', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (11, N'Dammam', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (12, N'Dubai', 3)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (13, N'Abu Dhabi', 3)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (14, N'Cairo', 5)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (15, N'Alexandria', 5)
INSERT [dbo].[Cities] ([CityID], [CityName], [CountryID]) VALUES (16, N'Amman', 6)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON

INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (1, 1, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (2, 2, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (3, 3, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (4, 4, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (5, 5, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (6, 6, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (7, 7, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (8, 8, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (9, 9, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (10, 10, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (11, 11, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (12, 12, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 1)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (13, 13, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (14, 14, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (15, 15, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (16, 16, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (17, 17, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (18, 18, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (19, 19, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (20, 20, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (21, 21, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (22, 22, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (23, 23, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (24, 24, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (25, 25, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (26, 26, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (27, 27, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (28, 28, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (29, 29, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (30, 30, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (31, 31, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (32, 32, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (33, 33, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (34, 34, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (35, 35, 2, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (36, 36, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (37, 37, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (39, 39, 1, CAST(N'2026-08-31T01:15:05.627' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (45, 1054, 1, CAST(N'2026-09-26T01:37:16.927' AS DateTime), 0)
INSERT [dbo].[Clients] ([ClientID], [PersonID], [ClientType], [CreatedDate], [Status]) VALUES (46, 1056, 1, CAST(N'2026-11-16T22:52:12.563' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON

INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (1, N'Yemen', N'YEM', N'+967', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Yemen.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (2, N'Saudi Arabia', N'SA', N'+966', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Saudi.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (3, N'United Arab Emirates', N'AE', N'+971', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\UnitatedArabEmarat.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (4, N'Qatar', N'QA', N'+974', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Qatar.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (5, N'Egypt', N'EG', N'+20', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Egypt.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (6, N'Jordan', N'JO', N'+962', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Jordan.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (7, N'Oman', N'OM', N'+968', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Oman.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (8, N'Kuwait', N'KW', N'+965', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Kuwait.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (9, N'Bahrain', N'BH', N'+973', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Barhain.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (10, N'Iraq', N'IQ', N'+964', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Iraq.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (11, N'Lebanon', N'LB', N'+961', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Lebanon.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (12, N'Palestine', N'PS', N'+970', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Palestine.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (13, N'Sudan', N'SD', N'+249', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\sudann.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (14, N'Syria', N'SY', N'+963', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Syria.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (15, N'Turkey', N'TR', N'+90', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Turkey.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (16, N'Malaysia', N'MY', N'+60', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Malaysia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (17, N'United States', N'US', N'+1', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\United_States.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (18, N'United Kingdom', N'GB', N'+44', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\United_Kingdom.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (19, N'Canada', N'CA', N'+1', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Canada.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (20, N'Australia', N'AU', N'+61', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Australia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (21, N'Germany', N'DE', N'+49', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Germany.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (22, N'France', N'FR', N'+33', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\France.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (23, N'Italy', N'IT', N'+39', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Italy.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (24, N'Spain', N'ES', N'+34', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Spain.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (25, N'China', N'CN', N'+86', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\China.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (26, N'Japan', N'JP', N'+81', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Japan.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (27, N'India', N'IN', N'+91', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\India.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (28, N'Pakistan', N'PK', N'+92', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Pakistan.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (29, N'Afghanistan', N'AF', N'+93', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Afghanistan.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (30, N'Algeria', N'DZ', N'+213', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Algeria.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (31, N'Argentina', N'AR', N'+54', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Argentina.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (32, N'Austria', N'AT', N'+43', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Austria.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (33, N'Brazil', N'BR', N'+55', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Brazil.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (34, N'Comoros', N'KM', N'+269', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\comoros.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (35, N'Djibouti', N'DJ', N'+253', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Djibouti.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (36, N'Indonesia', N'ID', N'+62', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Indonesia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (37, N'Libya', N'LY', N'+218', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Libya.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (38, N'Mauritania', N'MR', N'+222', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Mauritania.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (39, N'Mexico', N'MX', N'+52', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Mexico.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (40, N'Morocco', N'MA', N'+212', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Morocco.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (41, N'Netherlands', N'NL', N'+31', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Netherlands.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (42, N'New Zealand', N'NZ', N'+64', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\New_Zealand.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (43, N'Norway', N'NO', N'+47', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Norway.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (44, N'Philippines', N'PH', N'+63', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Philippines.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (45, N'Poland', N'PL', N'+48', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Poland.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (46, N'Russia', N'RU', N'+7', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Russia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (47, N'Singapore', N'SG', N'+65', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Singapore.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (48, N'Somalia', N'SO', N'+252', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Somalia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (49, N'South Africa', N'ZA', N'+27', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\South_Africa.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (50, N'South Korea', N'KR', N'+82', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\south_Korea.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (51, N'Sweden', N'SE', N'+46', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Sweden.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (52, N'Switzerland', N'CH', N'+41', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Switzerland.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (53, N'Thailand', N'TH', N'+66', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Thailand.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (54, N'Tunisia', N'TN', N'+216', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Tunisia.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (55, N'Ukraine', N'UA', N'+380', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Ukraine.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (56, N'Vietnam', N'VN', N'+84', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Vietnam.png')
INSERT [dbo].[Countries] ([CountryID], [CountryName], [CountryCode], [PhoneCode], [FlagPath]) VALUES (57, N'Zimbabwe', N'ZW', N'+263', N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Zimbabwe.png')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON

INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (1, N'USD', N'US Dollar', N'$', CAST(1.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\United_States.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (2, N'YER', N'Yemeni Rial', N'YER', CAST(540.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Yemen.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (3, N'SAR', N'Saudi Riyal', N'SAR', CAST(17.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Saudi.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (4, N'EUR', N'Euro', N'€', CAST(0.9200 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Germany.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (5, N'AED', N'UAE Dirham', N'AED', CAST(-55.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\UnitatedArabEmarat.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (6, N'GBP', N'British Pound', N'£', CAST(0.7900 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\United_Kingdom.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (7, N'KWD', N'Kuwaiti Dinar', N'KWD', CAST(0.3100 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Kuwait.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (8, N'QAR', N'Qatari Riyal', N'QAR', CAST(3.6400 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Qatar.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (9, N'OMR', N'Omani Riyal', N'OMR', CAST(0.3850 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Oman.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (10, N'BHD', N'Bahraini Dinar', N'BHD', CAST(0.3760 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Barhain.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (11, N'JOD', N'Jordanian Dinar', N'JOD', CAST(0.7090 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Jordan.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (12, N'EGP', N'Egyptian Pound', N'EGP', CAST(48.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Egypt.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (13, N'CAD', N'Canadian Dollar', N'CAD', CAST(1.3500 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Canada.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (14, N'AUD', N'Australian Dollar', N'AUD', CAST(1.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Australia.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (15, N'CHF', N'Swiss Franc', N'CHF', CAST(0.8800 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Switzerland.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (16, N'JPY', N'Japanese Yen', N'¥', CAST(155.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Japan.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (17, N'CNY', N'Chinese Yuan', N'CNY', CAST(7.2500 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\China.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (18, N'INR', N'Indian Rupee', N'?', CAST(83.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\India.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (19, N'TRY', N'Turkish Lira', N'?', CAST(34.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Turkey.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (20, N'MYR', N'Malaysian Ringgit', N'MYR', CAST(4.7000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Malaysia.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (21, N'SGD', N'Singapore Dollar', N'SGD', CAST(1.3500 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Singapore.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (22, N'SEK', N'Swedish Krona', N'kr', CAST(10.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Sweden.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (23, N'NOK', N'Norwegian Krone', N'kr', CAST(10.8000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Norway.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (24, N'DKK', N'Danish Krone', N'kr', CAST(6.8500 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Denmark.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (25, N'NZD', N'New Zealand Dollar', N'NZD', CAST(1.6500 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\New_Zealand.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (26, N'ZAR', N'South African Rand', N'R', CAST(18.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\South_Africa.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (27, N'BRL', N'Brazilian Real', N'R$', CAST(5.5000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Brazil.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (28, N'RUB', N'Russian Ruble', N'?', CAST(91.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Russia.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (29, N'IDR', N'Indonesian Rupiah', N'Rp', CAST(16000.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Indonesia.png')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName], [CurrencySymbol], [ExchangeRate], [IsActive], [FlagPath]) VALUES (30, N'PKR', N'Pakistani Rupee', N'?', CAST(278.0000 AS Decimal(18, 4)), 1, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CountriesFlag\Pakistan.png')
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[CurrencyRateHistory] ON

INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (37, 5, CAST(0.000000 AS Decimal(18, 6)), CAST(0.000000 AS Decimal(18, 6)), CAST(55.000000 AS Decimal(18, 6)), CAST(0.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:10:09.7200000' AS DateTime2), N'Updated via system')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (38, 1, CAST(0.000000 AS Decimal(18, 6)), CAST(0.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(540.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:10:39.6933333' AS DateTime2), N'Updated via system')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (39, 1, CAST(530.000000 AS Decimal(18, 6)), CAST(540.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(540.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:11:29.6800000' AS DateTime2), N'Updated via system')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (40, 1, CAST(10.000000 AS Decimal(18, 6)), CAST(10.000000 AS Decimal(18, 6)), CAST(10.000000 AS Decimal(18, 6)), CAST(10.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (41, 2, CAST(530.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (42, 3, CAST(3.750000 AS Decimal(18, 6)), CAST(3.750000 AS Decimal(18, 6)), CAST(3.750000 AS Decimal(18, 6)), CAST(3.750000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (43, 4, CAST(0.920000 AS Decimal(18, 6)), CAST(0.920000 AS Decimal(18, 6)), CAST(0.920000 AS Decimal(18, 6)), CAST(0.920000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (44, 5, CAST(-55.000000 AS Decimal(18, 6)), CAST(-55.000000 AS Decimal(18, 6)), CAST(-55.000000 AS Decimal(18, 6)), CAST(-55.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (45, 6, CAST(0.790000 AS Decimal(18, 6)), CAST(0.790000 AS Decimal(18, 6)), CAST(0.790000 AS Decimal(18, 6)), CAST(0.790000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (46, 7, CAST(0.310000 AS Decimal(18, 6)), CAST(0.310000 AS Decimal(18, 6)), CAST(0.310000 AS Decimal(18, 6)), CAST(0.310000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (47, 8, CAST(3.640000 AS Decimal(18, 6)), CAST(3.640000 AS Decimal(18, 6)), CAST(3.640000 AS Decimal(18, 6)), CAST(3.640000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (48, 9, CAST(0.385000 AS Decimal(18, 6)), CAST(0.385000 AS Decimal(18, 6)), CAST(0.385000 AS Decimal(18, 6)), CAST(0.385000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (49, 10, CAST(0.376000 AS Decimal(18, 6)), CAST(0.376000 AS Decimal(18, 6)), CAST(0.376000 AS Decimal(18, 6)), CAST(0.376000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (50, 11, CAST(0.709000 AS Decimal(18, 6)), CAST(0.709000 AS Decimal(18, 6)), CAST(0.709000 AS Decimal(18, 6)), CAST(0.709000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (51, 12, CAST(48.500000 AS Decimal(18, 6)), CAST(48.500000 AS Decimal(18, 6)), CAST(48.500000 AS Decimal(18, 6)), CAST(48.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (52, 13, CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (53, 14, CAST(1.500000 AS Decimal(18, 6)), CAST(1.500000 AS Decimal(18, 6)), CAST(1.500000 AS Decimal(18, 6)), CAST(1.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (54, 15, CAST(0.880000 AS Decimal(18, 6)), CAST(0.880000 AS Decimal(18, 6)), CAST(0.880000 AS Decimal(18, 6)), CAST(0.880000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (55, 16, CAST(155.000000 AS Decimal(18, 6)), CAST(155.000000 AS Decimal(18, 6)), CAST(155.000000 AS Decimal(18, 6)), CAST(155.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (56, 17, CAST(7.250000 AS Decimal(18, 6)), CAST(7.250000 AS Decimal(18, 6)), CAST(7.250000 AS Decimal(18, 6)), CAST(7.250000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (57, 18, CAST(83.500000 AS Decimal(18, 6)), CAST(83.500000 AS Decimal(18, 6)), CAST(83.500000 AS Decimal(18, 6)), CAST(83.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (58, 19, CAST(34.000000 AS Decimal(18, 6)), CAST(34.000000 AS Decimal(18, 6)), CAST(34.000000 AS Decimal(18, 6)), CAST(34.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (59, 20, CAST(4.700000 AS Decimal(18, 6)), CAST(4.700000 AS Decimal(18, 6)), CAST(4.700000 AS Decimal(18, 6)), CAST(4.700000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (60, 21, CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), CAST(1.350000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (61, 22, CAST(10.500000 AS Decimal(18, 6)), CAST(10.500000 AS Decimal(18, 6)), CAST(10.500000 AS Decimal(18, 6)), CAST(10.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (62, 23, CAST(10.800000 AS Decimal(18, 6)), CAST(10.800000 AS Decimal(18, 6)), CAST(10.800000 AS Decimal(18, 6)), CAST(10.800000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (63, 24, CAST(6.850000 AS Decimal(18, 6)), CAST(6.850000 AS Decimal(18, 6)), CAST(6.850000 AS Decimal(18, 6)), CAST(6.850000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (64, 25, CAST(1.650000 AS Decimal(18, 6)), CAST(1.650000 AS Decimal(18, 6)), CAST(1.650000 AS Decimal(18, 6)), CAST(1.650000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (65, 26, CAST(18.500000 AS Decimal(18, 6)), CAST(18.500000 AS Decimal(18, 6)), CAST(18.500000 AS Decimal(18, 6)), CAST(18.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (66, 27, CAST(5.500000 AS Decimal(18, 6)), CAST(5.500000 AS Decimal(18, 6)), CAST(5.500000 AS Decimal(18, 6)), CAST(5.500000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (67, 28, CAST(91.000000 AS Decimal(18, 6)), CAST(91.000000 AS Decimal(18, 6)), CAST(91.000000 AS Decimal(18, 6)), CAST(91.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (68, 29, CAST(16000.000000 AS Decimal(18, 6)), CAST(16000.000000 AS Decimal(18, 6)), CAST(16000.000000 AS Decimal(18, 6)), CAST(16000.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (69, 30, CAST(278.000000 AS Decimal(18, 6)), CAST(278.000000 AS Decimal(18, 6)), CAST(278.000000 AS Decimal(18, 6)), CAST(278.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T16:18:08.8433333' AS DateTime2), N'First Refresh Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (70, 2, CAST(530.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(520.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T19:32:16.4000000' AS DateTime2), N'Updated via system')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (71, 2, CAST(520.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), CAST(540.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-25T22:52:54.9200000' AS DateTime2), N'change rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (72, 2, CAST(530.000000 AS Decimal(18, 6)), CAST(540.000000 AS Decimal(18, 6)), CAST(520.000000 AS Decimal(18, 6)), CAST(530.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-26T01:13:31.4766667' AS DateTime2), N'Change Rate')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (73, 3, CAST(3.750000 AS Decimal(18, 6)), CAST(3.750000 AS Decimal(18, 6)), CAST(4.000000 AS Decimal(18, 6)), CAST(5.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-09-26T01:42:31.6566667' AS DateTime2), N'Updated via system')
INSERT [dbo].[CurrencyRateHistory] ([RateHistoryID], [CurrencyID], [OldBuyRate], [OldSellRate], [NewBuyRate], [NewSellRate], [ChangedByUserID], [ChangedDate], [ChangeReason]) VALUES (74, 3, CAST(4.000000 AS Decimal(18, 6)), CAST(5.000000 AS Decimal(18, 6)), CAST(413.000000 AS Decimal(18, 6)), CAST(430.000000 AS Decimal(18, 6)), N'USR-2026-0001', CAST(N'2026-11-16T22:59:25.1366667' AS DateTime2), N'Updated via system')
SET IDENTITY_INSERT [dbo].[CurrencyRateHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[DailyBranchSummary] ON

INSERT [dbo].[DailyBranchSummary] ([SummaryID], [BranchID], [OpeningBalance], [TotalTax], [ClosingBalance], [TotalTransactionsCount], [LatestUpdateDate]) VALUES (1011, 1, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 14, CAST(N'2026-08-31T01:15:05.637' AS DateTime))
INSERT [dbo].[DailyBranchSummary] ([SummaryID], [BranchID], [OpeningBalance], [TotalTax], [ClosingBalance], [TotalTransactionsCount], [LatestUpdateDate]) VALUES (1012, 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 11, CAST(N'2026-08-31T01:15:05.637' AS DateTime))
INSERT [dbo].[DailyBranchSummary] ([SummaryID], [BranchID], [OpeningBalance], [TotalTax], [ClosingBalance], [TotalTransactionsCount], [LatestUpdateDate]) VALUES (1013, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 7, CAST(N'2026-08-31T01:15:05.637' AS DateTime))
SET IDENTITY_INSERT [dbo].[DailyBranchSummary] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON

INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (3, N'Credit & Loans Management')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (6, N'Customer Service & Communication')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (7, N'Human Resources')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (1, N'Information Technology & Development')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (2, N'Retail Banking')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (5, N'Risk Management & Compliance')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (4, N'Treasury & Financial Operations')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[LoanGuarantors] ON

INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1047, 15, 1, N'Commercial Guarantor - First Choice', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1048, 16, 2, N'Personal & Primary Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1049, 17, 3, N'Real Estate Mortgage & Documents', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1050, 18, 4, N'Commercial Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1051, 16, 5, N'Personal & Primary Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1052, 19, 6, N'Salary Assignment Guarantee', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1053, 20, 7, N'Real Estate Mortgage', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1054, 21, 8, N'Commercial Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1055, 22, 9, N'Personal Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1056, 15, 10, N'Real Estate Mortgage', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1057, 17, 11, N'Salary Assignment Guarantee', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1058, 18, 12, N'Commercial Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1059, 19, 13, N'Personal Guarantor', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1060, 20, 14, N'Real Estate Mortgage', CAST(N'2026-08-31' AS Date))
INSERT [dbo].[LoanGuarantors] ([GuarantorID], [PersonID], [LoanID], [GuarantorType], [GuaranteedDate]) VALUES (1061, 21, 15, N'Commercial Guarantor - Second Choice', CAST(N'2026-08-31' AS Date))
SET IDENTITY_INSERT [dbo].[LoanGuarantors] OFF
GO
SET IDENTITY_INSERT [dbo].[LoanInstallments] ON

INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (1, 1, CAST(N'2025-02-01' AS Date), CAST(933.33 AS Decimal(18, 2)), CAST(N'2025-01-29' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (2, 1, CAST(N'2025-03-01' AS Date), CAST(933.33 AS Decimal(18, 2)), CAST(N'2025-02-27' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (3, 1, CAST(N'2025-04-01' AS Date), CAST(933.33 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (4, 1, CAST(N'2025-05-01' AS Date), CAST(933.33 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (5, 2, CAST(N'2025-03-01' AS Date), CAST(1400.00 AS Decimal(18, 2)), CAST(N'2025-02-28' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (6, 2, CAST(N'2025-04-01' AS Date), CAST(1400.00 AS Decimal(18, 2)), CAST(N'2025-03-30' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (7, 3, CAST(N'2025-04-01' AS Date), CAST(741.67 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (8, 4, CAST(N'2024-12-01' AS Date), CAST(1166.67 AS Decimal(18, 2)), CAST(N'2024-11-28' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (9, 5, CAST(N'2024-07-01' AS Date), CAST(95833.00 AS Decimal(18, 2)), CAST(N'2024-06-30' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (10, 5, CAST(N'2024-08-01' AS Date), CAST(95833.00 AS Decimal(18, 2)), CAST(N'2024-07-28' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (11, 5, CAST(N'2024-09-01' AS Date), CAST(95833.00 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (12, 6, CAST(N'2025-02-15' AS Date), CAST(1116.67 AS Decimal(18, 2)), CAST(N'2025-02-14' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (13, 7, CAST(N'2024-09-01' AS Date), CAST(1395.83 AS Decimal(18, 2)), CAST(N'2024-08-30' AS Date), 2)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (14, 8, CAST(N'2025-04-01' AS Date), CAST(450.00 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[LoanInstallments] ([LoanInstallmentID], [LoanID], [DueDate], [AmountDue], [PaidDate], [Status]) VALUES (15, 9, CAST(N'2025-05-01' AS Date), CAST(1675.00 AS Decimal(18, 2)), NULL, 1)
SET IDENTITY_INSERT [dbo].[LoanInstallments] OFF
GO
SET IDENTITY_INSERT [dbo].[Loans] ON

INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (1, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(11200.00 AS Decimal(18, 2)), CAST(N'2025-01-01' AS Date), CAST(N'2025-12-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (2, 2, CAST(15000.00 AS Decimal(18, 2)), CAST(16800.00 AS Decimal(18, 2)), CAST(N'2025-02-01' AS Date), CAST(N'2026-02-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (3, 3, CAST(8000.00 AS Decimal(18, 2)), CAST(8900.00 AS Decimal(18, 2)), CAST(N'2025-03-01' AS Date), CAST(N'2026-03-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (4, 4, CAST(25000.00 AS Decimal(18, 2)), CAST(28000.00 AS Decimal(18, 2)), CAST(N'2024-11-01' AS Date), CAST(N'2026-11-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (5, 5, CAST(2000000.00 AS Decimal(18, 2)), CAST(2300000.00 AS Decimal(18, 2)), CAST(N'2024-06-01' AS Date), CAST(N'2026-06-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (6, 6, CAST(12000.00 AS Decimal(18, 2)), CAST(13400.00 AS Decimal(18, 2)), CAST(N'2025-01-15' AS Date), CAST(N'2026-01-15' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (7, 7, CAST(30000.00 AS Decimal(18, 2)), CAST(33500.00 AS Decimal(18, 2)), CAST(N'2024-08-01' AS Date), CAST(N'2026-08-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (8, 8, CAST(5000.00 AS Decimal(18, 2)), CAST(5400.00 AS Decimal(18, 2)), CAST(N'2025-03-01' AS Date), CAST(N'2026-03-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (9, 9, CAST(18000.00 AS Decimal(18, 2)), CAST(20100.00 AS Decimal(18, 2)), CAST(N'2025-04-01' AS Date), CAST(N'2026-04-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (10, 10, CAST(22000.00 AS Decimal(18, 2)), CAST(24600.00 AS Decimal(18, 2)), CAST(N'2024-10-01' AS Date), CAST(N'2026-10-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (11, 11, CAST(14000.00 AS Decimal(18, 2)), CAST(15700.00 AS Decimal(18, 2)), CAST(N'2025-05-01' AS Date), CAST(N'2026-05-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (12, 2, CAST(9000.00 AS Decimal(18, 2)), CAST(10100.00 AS Decimal(18, 2)), CAST(N'2025-06-01' AS Date), CAST(N'2026-06-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (13, 3, CAST(35000.00 AS Decimal(18, 2)), CAST(39200.00 AS Decimal(18, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2026-09-01' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (14, 4, CAST(16000.00 AS Decimal(18, 2)), CAST(17900.00 AS Decimal(18, 2)), CAST(N'2025-02-15' AS Date), CAST(N'2026-02-15' AS Date), 1)
INSERT [dbo].[Loans] ([LoanID], [ClientID], [LoanAmount], [TotalAmount], [StartDate], [EndDate], [Status]) VALUES (15, 5, CAST(40000.00 AS Decimal(18, 2)), CAST(44800.00 AS Decimal(18, 2)), CAST(N'2024-12-01' AS Date), CAST(N'2026-12-01' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Loans] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON

INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1, N'Transfer Notification', N'A transfer of 90,000.00 YER has been made from account 3030-003-YER to account 5050-005-YER.', CAST(N'2026-09-25T01:30:11.180' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1001, N'Deposit Notification', N'Successfully deposited $1,500.00 to account [1010-001-YER].', CAST(N'2026-09-25T19:35:42.870' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1002, N'Deposit Notification', N'Successfully deposited $450,000.00 to account [2424-024-INR].', CAST(N'2026-09-25T19:48:05.400' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1003, N'Withdraw Notification', N'Successfully withdraw $460,000.00 from account [5050-005-YER].', CAST(N'2026-09-25T19:48:29.833' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1004, N'Deposit Notification', N'Successfully deposited $200,000.00 to account [3030-003-YER].', CAST(N'2026-09-25T19:54:43.177' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1005, N'Withdraw Notification', N'Successfully withdraw $500.00 from account [1414-014-GBP].', CAST(N'2026-09-25T19:55:10.667' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1006, N'Withdraw Notification', N'Successfully withdraw $50,000.00 from account [8080-008-YER].', CAST(N'2026-09-25T20:00:48.393' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1007, N'Transfer Notification', N'A transfer of 20,000.00 YER has been made from account 3030-003-YER to account 5050-005-YER.', CAST(N'2026-09-25T22:50:04.147' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1008, N'Transfer Notification', N'A transfer of 501,000.00 YER has been made from account 1010-001-YER to account 3030-003-YER.', CAST(N'2026-09-25T23:24:39.820' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1009, N'Deposit Notification', N'Successfully deposited $700.00 to account [1717-017-OMR].', CAST(N'2026-09-25T23:25:18.817' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1010, N'Withdraw Notification', N'Successfully withdraw $50.00 from account [1515-015-KWD].', CAST(N'2026-09-25T23:26:09.627' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1011, N'Transfer Notification', N'A transfer of 50,000.00 YER has been made from account 1010-001-YER to account 5050-005-YER.', CAST(N'2026-09-26T01:11:08.717' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1012, N'Deposit Notification', N'Successfully deposited $600,000.00 to account [3030-003-YER].', CAST(N'2026-09-26T01:12:02.740' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1013, N'Transfer Notification', N'A transfer of 950,000.00 YER has been made from account 1010-001-YER to account 8080-008-YER.', CAST(N'2026-09-26T01:40:06.300' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1014, N'Deposit Notification', N'Successfully deposited $2,500.00 to account [1010-001-YER].', CAST(N'2026-09-26T01:41:35.527' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1015, N'Withdraw Notification', N'Successfully withdraw $3,000.00 from account [5050-005-YER].', CAST(N'2026-09-26T01:41:57.323' AS DateTime), 1, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1016, N'Transfer Notification', N'A transfer of 8,000.00 YER has been made from account 1010-001-YER to account 3030-003-YER.', CAST(N'2026-11-16T22:56:14.253' AS DateTime), 0, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1017, N'Deposit Notification', N'Successfully deposited $1,000,000.00 to account [1010-001-YER].', CAST(N'2026-11-16T22:57:33.447' AS DateTime), 0, 1, N'USR-2026-0001')
INSERT [dbo].[Notifications] ([NotificationID], [Title], [Message], [SentDate], [IsRead], [Status], [UserID]) VALUES (1018, N'Withdraw Notification', N'Successfully withdraw $1,000,000.00 from account [1010-001-YER].', CAST(N'2026-11-16T22:57:56.137' AS DateTime), 0, 1, N'USR-2026-0001')
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON

INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (1, N'Manage_Users', N'Add, update, delete, and change status of system users')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (2, N'Manage_Roles', N'Manage system roles and permissions')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (3, N'System_Settings', N'Modify general and financial system settings')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (4, N'View_Audit_Logs', N'Monitor system operations and audit logs')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (5, N'Full_Access', N'Absolute access to all screens and system operations')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (6, N'System_Maintenance', N'Database and system maintenance tools')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (7, N'View_Error_Logs', N'View error logs and system exceptions')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (8, N'Manage_Database', N'Technical privileges related to backup and settings')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (9, N'Developer_Tools', N'Access to development and system testing tools')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (10, N'View_Branch_Reports', N'View branch financial reports and daily movements')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (11, N'Approve_Transactions', N'Approve large cash transactions exceeding teller limits')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (12, N'Supervise_Tellers', N'Supervise tellers and handle shift closings')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (13, N'Manage_Branch_Accounts', N'Review customer accounts belonging to the branch')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (14, N'Perform_Deposit', N'Perform deposit operations for customers')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (15, N'Perform_Withdrawal', N'Perform cash withdrawal operations')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (16, N'Manage_Customers', N'Add and update basic customer information')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (17, N'Execute_Transfers', N'Execute internal and external transfers')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (18, N'Daily_Cash_Operations', N'Manage cash drawer and open/close daily shifts')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (19, N'View_Loan_Applications', N'Review submitted customer loan applications')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (20, N'Analyze_Risk', N'Input customer credit and financial analysis data')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (21, N'Approve_Reject_Loans', N'Approve or reject loan requests within specified limits')
INSERT [dbo].[Permissions] ([PermissionID], [PermissionName], [Description]) VALUES (22, N'View_Customer_Financials', N'View customer financial history and credit reports')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON

INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (1, N'NID1001', N'Ayman', N'Ameen', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ayman.png', 1, N'ayman.ameen@gmail.com', N'+967 730 062 999', N'Taiz, Jamal St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (2, N'NID1002', N'Mohammed', N'Noman', CAST(N'2026-09-26' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\MohammedNo.png', 1, N'm.noman@gmail.com', N'+967 783 020 427', N'Taiz, Al-Tahrir', 5, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (3, N'NID1003', N'Mohammed', N'Al-Hilali', CAST(N'2005-11-10' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\MohammedAlh.png', 1, N'm.alhilali@gmail.com', N'+967 713 784 171', N'Taiz, University Dist', 7, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (4, N'NID1004', N'Hafez', N'Mahfoudh', CAST(N'2026-09-25' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Hafez.png', 1, N'hafez.mahfoudh@gmail.com', N'+967 739 019 976', N'Taiz, Hawban', 7, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (5, N'NID1039', N'Osama', N'Al-Fatki', CAST(N'2000-06-20' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Osama.png', 1, N'osama.alfatki@gmail.com', N'+967 730 543 020', N'Taiz, Al-Masbah', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (6, N'NID1005', N'Amr', N'Al-Sabaei', CAST(N'2006-04-05' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Amr.png', 1, N'omar.alsabaei@gmail.com', N'+967 734 446 774', N'Taiz, Sinaa St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (7, N'NID1006', N'Abdelilah', N'Al-Sameai', CAST(N'2008-02-12' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Abdelilah.png', 1, N'a.alsameai@gmail.com', N'+967 730 784 122', N'Taiz, Bir Basha', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (8, N'NID1007', N'Yahya', N'Al-Bakkari', CAST(N'2005-09-30' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Yahya.png', 1, N'yahya.bakkari@gmail.com', N'+967 779 280 706', N'Taiz, Al-Tahrir', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (9, N'NID1009', N'Alaa', N'Al-Junaid', CAST(N'2026-09-25' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Alaa.png', 1, N'alaa.aljunaid@gmail.com', N'+967 776 055 834', N'Taiz, Al-Osoa', 6, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (10, N'NID1038', N'Mohammed', N'Rashad', CAST(N'2004-01-15' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\MohammedRa.png', 1, N'm.rashad@gmail.com', N'+967 775 202 281', N'Taiz, Main St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (11, N'NID1040', N'Waleed', N'Al-Nuwaib', CAST(N'2003-09-10' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Waleed.png', 1, N'waleed.alnuwaib@gmail.com', N'+967 779 123 399', N'Taiz, Jamal St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (12, N'NID1041', N'Qais', N'Abdelhamid', CAST(N'2002-03-25' AS Date), NULL, 1, N'qais.abdelhamid@gmail.com', N'+967 778 986 889', N'Taiz, Sabir', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (13, N'NID1008', N'Mohammed', N'Al-Sabri', CAST(N'2007-08-18' AS Date), NULL, 1, N'm.alsabri@gmail.com', N'+967 775 678 764', N'Taiz, Al-Rawdah', 5, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (14, N'NID1010', N'Ahmed', N'Hassan', CAST(N'2005-06-22' AS Date), NULL, 1, N'ahmed.hassan@gmail.com', N'+967 770 111 222', N'Taiz, Main St', 8, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (15, N'NID1011', N'Fatima', N'Al-Ahmadi', CAST(N'2008-01-14' AS Date), NULL, 2, N'fatima.alahmadi@gmail.com', N'+967 733 222 333', N'Taiz, Al-Masahed', 9, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (16, N'NID1012', N'Khaled', N'Al-Mansoor', CAST(N'2007-05-28' AS Date), NULL, 1, N'khaled.mansoor@gmail.com', N'+967 711 333 444', N'Taiz, Al-Masbah', 11, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (17, N'NID1013', N'Aya', N'Al-Qasi', CAST(N'2005-10-19' AS Date), NULL, 2, N'aya.alqasi@gmail.com', N'+967 775 444 555', N'Sanaa, Hadda St', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (18, N'NID1014', N'Youssef', N'Al-Baidhani', CAST(N'2006-03-08' AS Date), NULL, 1, N'youssef.b@gmail.com', N'+967 738 555 666', N'Aden, Crater', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (19, N'NID1015', N'Faris', N'Al-Shameri', CAST(N'2007-09-17' AS Date), NULL, 1, N'faris.shameri@gmail.com', N'+967 712 666 777', N'Taiz, Al-Nasser', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (20, N'NID1016', N'Reem', N'Al-Maqtari', CAST(N'2008-04-23' AS Date), NULL, 2, N'reem.m@gmail.com', N'+967 777 777 888', N'Taiz, Al-Kifah', 5, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (21, N'NID1017', N'Bilal', N'Al-Sharabi', CAST(N'2005-08-04' AS Date), NULL, 1, N'bilal.sharabi@gmail.com', N'+967 735 888 999', N'Taiz, Al-Amodi', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (22, N'NID1018', N'Mariam', N'Al-Sharjabi', CAST(N'2006-01-15' AS Date), NULL, 2, N'mariam.s@gmail.com', N'+967 714 999 000', N'Taiz, Al-Ghurabi', 4, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (23, N'NID1019', N'Osama', N'Al-Wafi', CAST(N'2007-11-09' AS Date), NULL, 1, N'osama.alwafi@gmail.com', N'+967 773 123 456', N'Taiz, Al-Kausar', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (24, N'NID1020', N'Sara', N'Al-Haj', CAST(N'2004-05-18' AS Date), NULL, 2, N'sara.haj@gmail.com', N'+967 734 567 890', N'Sanaa, Sixty St', 1, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (25, N'NID1021', N'Nasser', N'Al-Adeemi', CAST(N'2003-09-12' AS Date), NULL, 1, N'nasser.adeemi@gmail.com', N'+967 711 456 789', N'Taiz, Al-Turbah', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (26, N'NID1022', N'Amal', N'Al-Zubairi', CAST(N'2006-02-28' AS Date), NULL, 2, N'amal.zubairi@gmail.com', N'+967 772 345 678', N'Sanaa, Zubairi St', 1, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (27, N'NID1023', N'Hamzah', N'Al-Silwi', CAST(N'2005-07-07' AS Date), NULL, 1, N'hamzah.silwi@gmail.com', N'+967 736 789 012', N'Taiz, Al-Silw', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (28, N'NID1024', N'Noor', N'Al-Absi', CAST(N'2007-12-19' AS Date), NULL, 2, N'noor.absi@gmail.com', N'+967 715 890 123', N'Aden, Khormaksar', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (29, N'NID1025', N'Waleed', N'Al-Khadher', CAST(N'2004-10-30' AS Date), NULL, 1, N'waleed.k@gmail.com', N'+967 771 901 234', N'Taiz, Al-Hawban', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (30, N'NID1026', N'Yasmine', N'Al-Ansi', CAST(N'2008-03-14' AS Date), NULL, 2, N'yasmine.ansi@gmail.com', N'+967 737 012 345', N'Sanaa, Al-Tahrir', 1, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (31, N'NID1027', N'Marwan', N'Al-Thobhani', CAST(N'2003-11-05' AS Date), NULL, 1, N'marwan.th@gmail.com', N'+967 716 123 456', N'Taiz, Al-Masbah', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (32, N'NID1028', N'Mona', N'Al-Qubati', CAST(N'2005-04-22' AS Date), NULL, 2, N'mona.qubati@gmail.com', N'+967 774 234 567', N'Aden, Maala', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (33, N'NID1029', N'Ibrahim', N'Al-Ameri', CAST(N'2006-08-11' AS Date), NULL, 1, N'ibrahim.ameri@gmail.com', N'+967 738 345 678', N'Taiz, Sinaa St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (34, N'NID1030', N'Rania', N'Al-Kawkabani', CAST(N'2007-01-03' AS Date), NULL, 2, N'rania.k@gmail.com', N'+967 717 456 789', N'Sanaa, Old City', 1, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (35, N'NID1031', N'Sultan', N'Al-Sharabi', CAST(N'2004-06-25' AS Date), NULL, 1, N'sultan.s@gmail.com', N'+967 775 567 890', N'Taiz, Jamal St', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (36, N'NID1032', N'Hoda', N'Al-Rimi', CAST(N'2008-09-15' AS Date), NULL, 2, N'hoda.rimi@gmail.com', N'+967 739 678 901', N'Taiz, Bir Basha', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (37, N'NID1033', N'Bassem', N'Al-Odaini', CAST(N'2005-12-08' AS Date), NULL, 1, N'bassem.o@gmail.com', N'+967 718 789 012', N'Taiz, Al-Udayn', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (39, N'NID1035', N'Ziad', N'Al-Ahdal', CAST(N'2003-03-29' AS Date), NULL, 1, N'ziad.ahdal@gmail.com', N'+967 731 901 234', N'Hodeidah, Main St', 4, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (41, N'NID1037', N'Majed', N'Al-Sharabi', CAST(N'2004-11-21' AS Date), NULL, 1, N'majed.s@gmail.com', N'+967 777 123 999', N'Taiz, Al-Masbah', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (42, N'NID1042', N'Oday', N'Al-Naqeeb', CAST(N'2006-08-06' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\UsersImage\Oday.JPG', 1, N'alnaqeboday105@gmail.com', N'+967 783 042 889', N'Taiz, Bir Basha', 2, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (43, N'6895476852', N'Salah', N'Al-Naqeeb', CAST(N'1995-05-12' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\UsersImage\Salah.jpg', 1, N'salah@gmail.com', N'777123456', N'Taizz', NULL, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (44, N'NID1044', N'Laila', N'Al-Maswari', CAST(N'2005-03-09' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Resources\DefaultFemaleAvatar.png', 0, N'laila@gmail.com', N'+967 ### ### ###', N'Sanaa, Old City', 1, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (47, N'892877360', N'SoSo', N'KoKo', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ragi.png', 2, N'nnn', N'87878654645', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (49, N'892877355', N'SoSo', N'KoKo', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ragi.png', 2, N'nnn', N'87878654645', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (51, N'89287856947', N'SoSo', N'KoKo', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ragi.png', 2, N'nnn', N'87878654645', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (53, N'256489', N'SoSo', N'KoKo', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ragi.png', 2, N'nnn', N'87878654645', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (56, N'00000000000000', N'SoSo', N'KoKo', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Ragi.png', 2, N'nnn', N'87878654645', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (58, N'319775359', N'sosiii', N'isi', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Yahya.png', 1, N'dddd', N'4444', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (60, N'NID1047', N'sosiii', N'isi', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Yahya.png', 1, N'dddd', N'4444', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (62, N'323232323', N'sosiii', N'isi', CAST(N'2026-09-01' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Yahya.png', 1, N'dddd', N'4444', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (64, N'66666666', N'dfdd', N'ff', CAST(N'2026-09-01' AS Date), NULL, 1, N'dd', N'888', N'', 3, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (1051, N'6354892465', N'Salah', N'Al-Naqeeb', NULL, N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\UsersImage\Salah.JPG', 1, NULL, NULL, NULL, NULL, N'Client')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (1053, N'654678922', N'Ali', N'Salih', NULL, N'', 1, N'alisalih@gmail.com', N'783042889', NULL, NULL, N'User')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (1054, N'320098454', N'Sara', N'Mohammed', CAST(N'2026-09-26' AS Date), N'', 2, N'saraali@gmail.com', N'775252321', NULL, 3, N'Client')
INSERT [dbo].[Persons] ([PersonID], [NationalID], [FirstName], [LastName], [DateOfBirth], [ImagePath], [Gender], [Email], [Phone], [Address], [CityID], [PersonType]) VALUES (1056, N'4544453198', N'Shihab', N'Alrihawe', CAST(N'2004-06-15' AS Date), N'C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage\Shihab.png.jpeg', 1, N'shihab@gmail.com', N'779728457', NULL, 2, N'Client')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (1, 1)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (1, 2)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (1, 3)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (1, 4)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (1, 5)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (2, 6)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (2, 7)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (2, 8)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (2, 9)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (3, 10)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (3, 11)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (3, 12)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (3, 13)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (4, 14)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (4, 15)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (4, 16)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (4, 17)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (4, 18)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (5, 19)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (5, 20)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (5, 21)
INSERT [dbo].[RolePermissions] ([RoleID], [PermissionID]) VALUES (5, 22)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (1, N'Full Admin (ALL)', N'Security Manager Full control over system and users')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (2, N'System Developer', N'Technical access and system maintenance')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (3, N'Branch Supervisor', N'Supervision of exchange operations and reports')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (4, N'Teller / Operations', N'Perform deposits, withdrawals, and daily cash operations')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (5, N'Loan Analyst', N'Review, analysis, and approval of customer loans')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON

INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1, NULL, 1, N'1', 1, 1, N'2', CAST(500000.00 AS Decimal(18, 2)), CAST(N'2025-01-10T09:30:00.000' AS DateTime), N'Cash liquidity deposit', 1, NULL, N'Ayman Al-Sabri', CAST(500000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (2, 1, NULL, N'2', 1, 1, N'2', CAST(500050.00 AS Decimal(18, 2)), CAST(N'2025-01-12T11:15:00.000' AS DateTime), N'ATM Withdrawal from Main Branch', 1, N'Ayman Al-Sabri', NULL, CAST(449950.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (3, 1, 5, N'3', 1, 1, N'2', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2025-01-15T14:00:00.000' AS DateTime), N'Family support transfer', 1, N'Ayman Al-Sabri', N'Sami Al-Dhubhani', CAST(349950.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (4, 2, 6, N'3', 2, 1, N'1', CAST(1200.00 AS Decimal(18, 2)), CAST(N'2025-01-18T10:20:00.000' AS DateTime), N'International digital services payment', 1, N'Ayman Al-Sabri', N'Abdelilah Al-Sameai', CAST(18800.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (5, NULL, 3, N'1', 2, 2, N'1', CAST(50000.00 AS Decimal(18, 2)), CAST(N'2025-02-01T10:00:00.000' AS DateTime), N'Commercial check deposit', 1, NULL, N'Marwan Al-Sharabi', CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (6, 3, 4, N'3', 2, 2, N'1', CAST(10000.00 AS Decimal(18, 2)), CAST(N'2025-02-03T16:20:00.000' AS DateTime), N'Currency purchase and Saudi account funding', 1, N'Marwan Al-Sharabi', N'Marwan Al-Sharabi', CAST(40000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (7, 2, 6, N'3', 2, 1, N'1', CAST(500.00 AS Decimal(18, 2)), CAST(N'2025-02-10T12:45:00.000' AS DateTime), N'Electronic goods payment at Hadda store', 1, N'Ayman Al-Sabri', N'Yasser Al-Zubaidi', CAST(18300.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (8, 7, NULL, N'5', 1, 5, N'2', CAST(95833.00 AS Decimal(18, 2)), CAST(N'2025-02-15T08:30:00.000' AS DateTime), N'Automated loan installment deduction', 1, N'Sami Al-Dhubhani', N'Bank Administration', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (9, 5, 1, N'3', 1, 5, N'2', CAST(250000.00 AS Decimal(18, 2)), CAST(N'2025-02-18T13:10:00.000' AS DateTime), N'Payroll transfer settlement', 1, N'Amr Al-Sabaei', N'Ayman Al-Sabri', CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (10, 4, 7, N'4', 3, 2, N'3', CAST(15000.00 AS Decimal(18, 2)), CAST(N'2025-02-22T15:00:00.000' AS DateTime), N'External remittance to Riyadh branch', 1, N'Marwan Al-Sharabi', N'Yahya Al-Bakkari', CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (11, NULL, 8, N'1', 1, 8, N'4', CAST(300000.00 AS Decimal(18, 2)), CAST(N'2025-03-01T09:00:00.000' AS DateTime), N'Initial capital cash deposit', 0, NULL, N'Mohammed Al-Sabri', CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (12, 8, 2, N'3', 1, 8, N'4', CAST(75000.00 AS Decimal(18, 2)), CAST(N'2025-03-05T11:30:00.000' AS DateTime), N'Investment share contribution', 0, N'Mohammed Al-Sabri', N'Ayman Al-Sabri', CAST(225000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (13, 3, NULL, N'6', 2, 2, N'1', CAST(450.00 AS Decimal(18, 2)), CAST(N'2025-03-08T14:15:00.000' AS DateTime), N'POS Supermarket purchase - Sanaa', 0, N'Marwan Al-Sharabi', N'City Mart', CAST(39550.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (14, 6, 4, N'4', 4, 6, N'3', CAST(1200.00 AS Decimal(18, 2)), CAST(N'2025-03-12T16:40:00.000' AS DateTime), N'Euro transfer to commercial partner', 0, N'Abdelilah Al-Sameai', N'Global Trade Corp', CAST(8800.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (15, 9, 1, N'3', 3, 9, N'2', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2025-03-15T10:10:00.000' AS DateTime), N'SAR exchange settlement', 0, N'Alaa Al-Junaid', N'Ayman Al-Sabri', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (16, NULL, 5, N'1', 1, 5, N'2', CAST(450000.00 AS Decimal(18, 2)), CAST(N'2025-04-02T08:45:00.000' AS DateTime), N'Monthly corporate revenue deposit', 0, NULL, N'Amr Al-Sabaei', CAST(450000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (17, 5, 7, N'3', 1, 5, N'2', CAST(80000.00 AS Decimal(18, 2)), CAST(N'2025-04-06T12:00:00.000' AS DateTime), N'Consultancy fees payment', 1, N'Amr Al-Sabaei', N'Yahya Al-Bakkari', CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (18, 1, NULL, N'6', 2, 1, N'2', CAST(150.00 AS Decimal(18, 2)), CAST(N'2025-04-10T19:25:00.000' AS DateTime), N'Online software subscription purchase', 0, N'Ayman Al-Sabri', N'JetBrains s.r.o.', CAST(349800.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (19, 7, 3, N'3', 2, 7, N'3', CAST(2500.00 AS Decimal(18, 2)), CAST(N'2025-04-14T15:30:00.000' AS DateTime), N'Account liquidity rebalancing', 1, N'Yahya Al-Bakkari', N'Marwan Al-Sharabi', CAST(12500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (20, 2, NULL, N'2', 2, 1, N'1', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2025-04-20T11:00:00.000' AS DateTime), N'USD Cash withdrawal for travel', 0, N'Ayman Al-Sabri', NULL, CAST(13300.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (21, 4, 8, N'3', 3, 2, N'4', CAST(12000.00 AS Decimal(18, 2)), CAST(N'2025-05-03T10:15:00.000' AS DateTime), N'Equipment maintenance payment', 1, N'Marwan Al-Sharabi', N'Mohammed Al-Sabri', CAST(-7000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (22, NULL, 9, N'1', 3, 9, N'2', CAST(35000.00 AS Decimal(18, 2)), CAST(N'2025-05-07T13:50:00.000' AS DateTime), N'Branch cash injection deposit', 0, NULL, N'Alaa Al-Junaid', CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (23, 8, 6, N'3', 1, 8, N'1', CAST(60000.00 AS Decimal(18, 2)), CAST(N'2025-05-11T14:20:00.000' AS DateTime), N'Logistics support transfer', 1, N'Mohammed Al-Sabri', N'Abdelilah Al-Sameai', CAST(165000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (24, 3, NULL, N'6', 2, 2, N'1', CAST(890.00 AS Decimal(18, 2)), CAST(N'2025-05-15T20:00:00.000' AS DateTime), N'POS Electronics store purchase', 0, N'Marwan Al-Sharabi', N'Samsung Store', CAST(38660.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (25, 6, 1, N'3', 4, 6, N'3', CAST(300.00 AS Decimal(18, 2)), CAST(N'2025-05-22T09:40:00.000' AS DateTime), N'EUR currency conversion to YER', 0, N'Abdelilah Al-Sameai', N'Ayman Al-Sabri', CAST(8500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (26, NULL, 7, N'1', 2, 7, N'2', CAST(15000.00 AS Decimal(18, 2)), CAST(N'2025-06-01T10:00:00.000' AS DateTime), N'External wire transfer received', 1, NULL, N'Yahya Al-Bakkari', CAST(27500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (27, 7, NULL, N'5', 2, 7, N'2', CAST(95833.00 AS Decimal(18, 2)), CAST(N'2025-06-05T11:15:00.000' AS DateTime), N'Loan installment early settlement', 1, N'Yahya Al-Bakkari', N'Bank Administration', CAST(-68333.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (28, 5, 2, N'3', 1, 5, N'1', CAST(120000.00 AS Decimal(18, 2)), CAST(N'2025-06-10T13:30:00.000' AS DateTime), N'Partner profit distribution', 0, N'Amr Al-Sabaei', N'Ayman Al-Sabri', CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (29, 1, 4, N'3', 1, 1, N'2', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2025-06-15T15:45:00.000' AS DateTime), N'Inter-branch treasury funding', 0, N'Ayman Al-Sabri', N'Marwan Al-Sharabi', CAST(149800.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (30, 2, NULL, N'6', 2, 1, N'2', CAST(75.00 AS Decimal(18, 2)), CAST(N'2025-06-20T18:10:00.000' AS DateTime), N'POS Restaurant payment', 1, N'Ayman Al-Sabri', N'Al-Shibami Restaurant', CAST(13225.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (31, 3, 8, N'3', 2, 2, N'4', CAST(4500.00 AS Decimal(18, 2)), CAST(N'2025-06-24T11:20:00.000' AS DateTime), N'Consultation fees transfer', 0, N'Marwan Al-Sharabi', N'Mohammed Al-Sabri', CAST(34160.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (32, 6, NULL, N'2', 4, 6, N'1', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2025-06-26T14:00:00.000' AS DateTime), N'EUR Cash withdrawal', 0, N'Abdelilah Al-Sameai', NULL, CAST(7000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (33, 5, 7, N'3', 1, 3, N'USR-2026-0001', CAST(90000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T01:30:11.193' AS DateTime), N'Transfer from  3030-003-YER to 5050-005-YER Amount 90,000.00 ر.ي.‏', 1, NULL, NULL, CAST(800000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1001, NULL, 1, N'1', 1, 1, N'USR-2026-0001', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2026-09-25T19:35:42.867' AS DateTime), N'Deposit operation via system', 1, NULL, N'Ayman Ameen', CAST(3501500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1002, NULL, 26, N'1', 18, 3, N'USR-2026-0001', CAST(450000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T19:48:05.397' AS DateTime), N'Deposit operation via system', 1, NULL, N'Mohammed Al-Hilali', CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1003, NULL, 7, N'2', 1, 5, N'USR-2026-0001', CAST(460000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T19:48:29.827' AS DateTime), N'Withdraw operation via system', 1, N'Osama Al-Fatki', NULL, CAST(80000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1004, NULL, 5, N'1', 1, 3, N'USR-2026-0001', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T19:54:43.177' AS DateTime), N'Deposit operation via system', 1, NULL, N'Mohammed Al-Hilali', CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1005, NULL, 16, N'2', 6, 4, N'USR-2026-0001', CAST(500.00 AS Decimal(18, 2)), CAST(N'2026-09-25T19:55:10.660' AS DateTime), N'Withdraw operation via system', 1, N'Hafez Mahfoudh', NULL, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1006, NULL, 10, N'2', 1, 8, N'USR-2026-0001', CAST(50000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T20:00:48.383' AS DateTime), N'Withdraw operation via system', 1, N'Yahya Al-Bakkari', NULL, CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1007, 5, 7, N'3', 1, 3, N'USR-2026-0001', CAST(20000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T22:50:04.163' AS DateTime), N'Transfer from  3030-003-YER to 5050-005-YER Amount 20,000.00 ر.ي.‏', 1, NULL, NULL, CAST(980000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1008, 1, 5, N'3', 1, 1, N'USR-2026-0001', CAST(501000.00 AS Decimal(18, 2)), CAST(N'2026-09-25T23:24:39.837' AS DateTime), N'Transfer from  1010-001-YER to 3030-003-YER Amount 501,000.00 ر.ي.‏', 1, NULL, NULL, CAST(3000500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1009, NULL, 19, N'1', 9, 7, N'USR-2026-0001', CAST(700.00 AS Decimal(18, 2)), CAST(N'2026-09-25T23:25:18.813' AS DateTime), N'Deposit operation via system', 1, NULL, N'Abdelilah Al-Sameai', CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1010, NULL, 17, N'2', 7, 5, N'USR-2026-0001', CAST(50.00 AS Decimal(18, 2)), CAST(N'2026-09-25T23:26:09.620' AS DateTime), N'Withdraw operation via system', 1, N'Osama Al-Fatki', NULL, CAST(8350.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1011, 1, 7, N'3', 1, 1, N'USR-2026-0001', CAST(50000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:11:08.730' AS DateTime), N'Transfer from  1010-001-YER to 5050-005-YER Amount 50,000.00 ر.ي.‏', 1, NULL, NULL, CAST(2950500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1012, NULL, 5, N'1', 1, 3, N'USR-2026-0001', CAST(600000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:12:02.733' AS DateTime), N'Deposit operation via system', 1, NULL, N'Mohammed Al-Hilali', CAST(2081000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1013, 1, 10, N'3', 1, 1, N'USR-2026-0001', CAST(950000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:40:06.317' AS DateTime), N'Transfer from  1010-001-YER to 8080-008-YER Amount 950,000.00 ر.ي.‏', 1, NULL, NULL, CAST(2000500.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1014, 7, 5, N'3', 1, 5, N'USR-2026-0001', CAST(50000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:40:50.253' AS DateTime), N'Transfer from  5050-005-YER to 3030-003-YER Amount 50,000.00 ر.ي.‏', 1, NULL, NULL, CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1015, 7, 1, N'3', 1, 5, N'USR-2026-0001', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:40:58.337' AS DateTime), N'Transfer from  5050-005-YER to 1010-001-YER Amount 5,000.00 ر.ي.‏', 1, NULL, NULL, CAST(95000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1016, NULL, 1, N'1', 1, 1, N'USR-2026-0001', CAST(2500.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:41:35.523' AS DateTime), N'Deposit operation via system', 1, NULL, N'Ayman Ameen', CAST(2008000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1017, NULL, 7, N'2', 1, 5, N'USR-2026-0001', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2026-09-26T01:41:57.320' AS DateTime), N'Withdraw operation via system', 1, N'Osama Al-Fatki', NULL, CAST(92000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1018, 1, 5, N'3', 1, 1, N'USR-2026-0001', CAST(8000.00 AS Decimal(18, 2)), CAST(N'2026-11-16T22:56:14.270' AS DateTime), N'Transfer from  1010-001-YER to 3030-003-YER Amount 8,000.00 ر.ي.‏', 1, NULL, NULL, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1019, NULL, 1, N'1', 1, 1, N'USR-2026-0001', CAST(1000000.00 AS Decimal(18, 2)), CAST(N'2026-11-16T22:57:33.437' AS DateTime), N'Deposit operation via system', 1, NULL, N'Ayman Ameen', CAST(3000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionID], [FromAccountID], [ToAccountID], [TransactionTypeID], [CurrencyID], [PerformedByClientID], [ExecutedByUserID], [Amount], [TransactionDate], [Description], [Status], [FromClientName], [ToClientName], [AmountAfter]) VALUES (1020, NULL, 1, N'2', 1, 1, N'USR-2026-0001', CAST(1000000.00 AS Decimal(18, 2)), CAST(N'2026-11-16T22:57:56.130' AS DateTime), N'Withdraw operation via system', 1, N'Ayman Ameen', NULL, CAST(2000000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionType] ON

INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (1, N'Deposit')
INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (4, N'External Bank Transfer')
INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (3, N'Internal Account Transfer')
INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (5, N'Loan Installment Payment')
INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (6, N'POS Purchase')
INSERT [dbo].[TransactionType] ([TransactionTypeID], [TypeName]) VALUES (2, N'Withdraw')
SET IDENTITY_INSERT [dbo].[TransactionType] OFF
GO
INSERT [dbo].[UserCredentials] ([UserID], [Username], [PasswordHash], [PasswordSalt], [FailedLoginAttempts], [IsLocked], [LastLoginDate]) VALUES (N'USR-2026-0001', N'Oday Al-Naqeeb', N'321321321', N'salt_e6', 0, 0, CAST(N'2026-09-25T01:20:49.930' AS DateTime))
INSERT [dbo].[UserCredentials] ([UserID], [Username], [PasswordHash], [PasswordSalt], [FailedLoginAttempts], [IsLocked], [LastLoginDate]) VALUES (N'USR-2026-0002', N'Salah', N'123456', N'salt_e6', 0, 0, CAST(N'2026-09-26T00:10:58.377' AS DateTime))
INSERT [dbo].[UserCredentials] ([UserID], [Username], [PasswordHash], [PasswordSalt], [FailedLoginAttempts], [IsLocked], [LastLoginDate]) VALUES (N'USR-2026-0003', N'Laila', N'321321', N'salt_a2', 0, 0, CAST(N'2026-09-25T01:20:49.930' AS DateTime))
INSERT [dbo].[UserCredentials] ([UserID], [Username], [PasswordHash], [PasswordSalt], [FailedLoginAttempts], [IsLocked], [LastLoginDate]) VALUES (N'USR-2026-0005', N'ali', N'123654', NULL, 0, 0, NULL)
GO
INSERT [dbo].[UserRoles] ([UserID], [RoleID]) VALUES (N'USR-2026-0001', 1)
INSERT [dbo].[UserRoles] ([UserID], [RoleID]) VALUES (N'USR-2026-0002', 2)
INSERT [dbo].[UserRoles] ([UserID], [RoleID]) VALUES (N'USR-2026-0003', 4)
INSERT [dbo].[UserRoles] ([UserID], [RoleID]) VALUES (N'USR-2026-0005', 5)
GO
INSERT [dbo].[Users] ([UserID], [PersonID], [DepartmentID], [BranchID], [JobTitle], [HireDate], [Salary], [Status]) VALUES (N'USR-2026-0001', 42, 1, 1, N'Systems & Data Manager', CAST(N'2021-01-10' AS Date), CAST(1800.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Users] ([UserID], [PersonID], [DepartmentID], [BranchID], [JobTitle], [HireDate], [Salary], [Status]) VALUES (N'USR-2026-0002', 43, 2, 2, N'System Admin', CAST(N'2022-03-15' AS Date), CAST(1100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Users] ([UserID], [PersonID], [DepartmentID], [BranchID], [JobTitle], [HireDate], [Salary], [Status]) VALUES (N'USR-2026-0003', 44, 3, 3, N'Credit & Loan Analyst', CAST(N'2022-06-01' AS Date), CAST(1250.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Users] ([UserID], [PersonID], [DepartmentID], [BranchID], [JobTitle], [HireDate], [Salary], [Status]) VALUES (N'USR-2026-0005', 1053, 2, NULL, N'Loan Analyst', CAST(N'2026-09-26' AS Date), CAST(0.00 AS Decimal(18, 2)), 1)
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [UQ_Accounts_AccountNumber] UNIQUE NONCLUSTERED
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [UQ_Accounts_IBAN] UNIQUE NONCLUSTERED
(
	[IBAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[AccountTypes] ADD  CONSTRAINT [UQ_AccountTypes_TypeName] UNIQUE NONCLUSTERED
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Cards] ADD  CONSTRAINT [UQ_Cards_CardNumber] UNIQUE NONCLUSTERED
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [UQ_Clients_PersonID] UNIQUE NONCLUSTERED
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [UQ_Countries_Code] UNIQUE NONCLUSTERED
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Currencies] ADD  CONSTRAINT [UQ_Currencies_CurrencyCode] UNIQUE NONCLUSTERED
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [UQ_Departments_Name] UNIQUE NONCLUSTERED
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [UQ_Permissions_PermissionName] UNIQUE NONCLUSTERED
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Persons] ADD  CONSTRAINT [UQ_Persons_NationalID] UNIQUE NONCLUSTERED
(
	[NationalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [UQ_Roles_RoleName] UNIQUE NONCLUSTERED
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[TransactionType] ADD  CONSTRAINT [UQ_TransactionType_TypeName] UNIQUE NONCLUSTERED
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[UserCredentials] ADD  CONSTRAINT [UQ_UserCredentials_Username] UNIQUE NONCLUSTERED
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((0.00)) FOR [Balance]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AccountTypes] ADD  DEFAULT ((0.00)) FOR [InterestRate]
GO
ALTER TABLE [dbo].[AccountTypes] ADD  DEFAULT ((0.00)) FOR [MinimumBalance]
GO
ALTER TABLE [dbo].[Cards] ADD  DEFAULT ((1000.00)) FOR [DailyLimit]
GO
ALTER TABLE [dbo].[Cards] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Cards] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT ((1)) FOR [ClientType]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Currencies] ADD  DEFAULT ((1.0000)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[Currencies] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[CurrencyRateHistory] ADD  DEFAULT (getdate()) FOR [ChangedDate]
GO
ALTER TABLE [dbo].[DailyBranchSummary] ADD  DEFAULT ((0.00)) FOR [OpeningBalance]
GO
ALTER TABLE [dbo].[DailyBranchSummary] ADD  DEFAULT ((0.00)) FOR [TotalTax]
GO
ALTER TABLE [dbo].[DailyBranchSummary] ADD  DEFAULT ((0.00)) FOR [ClosingBalance]
GO
ALTER TABLE [dbo].[DailyBranchSummary] ADD  DEFAULT ((0)) FOR [TotalTransactionsCount]
GO
ALTER TABLE [dbo].[DailyBranchSummary] ADD  DEFAULT (getdate()) FOR [LatestUpdateDate]
GO
ALTER TABLE [dbo].[LoanGuarantors] ADD  DEFAULT (getdate()) FOR [GuaranteedDate]
GO
ALTER TABLE [dbo].[LoanInstallments] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Loans] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (getdate()) FOR [SentDate]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Persons] ADD  DEFAULT ('Client') FOR [PersonType]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[UserCredentials] ADD  DEFAULT ((0)) FOR [FailedLoginAttempts]
GO
ALTER TABLE [dbo].[UserCredentials] ADD  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0.00)) FOR [Salary]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_AccountTypes] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountTypes] ([AccountTypeID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_AccountTypes]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Branches]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Clients]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Currencies] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Currencies]
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Cities] FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Branches_Cities]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Accounts]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Persons]
GO
ALTER TABLE [dbo].[CurrencyRateHistory]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyRateHistory_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[CurrencyRateHistory] CHECK CONSTRAINT [FK_CurrencyRateHistory_Currency]
GO
ALTER TABLE [dbo].[DailyBranchSummary]  WITH CHECK ADD  CONSTRAINT [FK_DailyBranchSummary_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO
ALTER TABLE [dbo].[DailyBranchSummary] CHECK CONSTRAINT [FK_DailyBranchSummary_Branches]
GO
ALTER TABLE [dbo].[LoanGuarantors]  WITH CHECK ADD  CONSTRAINT [FK_LoanGuarantors_Loans] FOREIGN KEY([LoanID])
REFERENCES [dbo].[Loans] ([LoanID])
GO
ALTER TABLE [dbo].[LoanGuarantors] CHECK CONSTRAINT [FK_LoanGuarantors_Loans]
GO
ALTER TABLE [dbo].[LoanGuarantors]  WITH CHECK ADD  CONSTRAINT [FK_LoanGuarantors_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[LoanGuarantors] CHECK CONSTRAINT [FK_LoanGuarantors_Persons]
GO
ALTER TABLE [dbo].[LoanInstallments]  WITH CHECK ADD  CONSTRAINT [FK_LoanInstallments_Loans] FOREIGN KEY([LoanID])
REFERENCES [dbo].[Loans] ([LoanID])
GO
ALTER TABLE [dbo].[LoanInstallments] CHECK CONSTRAINT [FK_LoanInstallments_Loans]
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [FK_Loans_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [FK_Loans_Clients]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Cities] FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Cities]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissions] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permissions] ([PermissionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissions]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Currencies] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Currencies]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FromAccount] FOREIGN KEY([FromAccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FromAccount]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_PerformedByClient] FOREIGN KEY([PerformedByClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_PerformedByClient]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_ToAccount] FOREIGN KEY([ToAccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_ToAccount]
GO
ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_UserCredentials_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCredentials] CHECK CONSTRAINT [FK_UserCredentials_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [CHK_Cards_DailyLimit] CHECK  (([DailyLimit]>=(0)))
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [CHK_Cards_DailyLimit]
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD  CONSTRAINT [CHK_Loans_Amounts] CHECK  (([TotalAmount]>=[LoanAmount]))
GO
ALTER TABLE [dbo].[Loans] CHECK CONSTRAINT [CHK_Loans_Amounts]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [CHK_Transactions_Amount] CHECK  (([Amount]>(0)))
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [CHK_Transactions_Amount]
GO
