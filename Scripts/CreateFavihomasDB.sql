CREATE DATABASE Favihomas;
GO

BEGIN TRY
	BEGIN TRAN

	CREATE TABLE Favihomas.dbo.AuditActions (
		AuditActionID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		AuditAction VARCHAR(100) NOT NULL		
	);

	CREATE TABLE Favihomas.dbo.Users (
		UserID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		Username VARCHAR(100) NOT NULL,
		Password VARCHAR(100) NOT NULL,
		Status BIT NOT NULL,
		DateCreated DATETIME NOT NULL,
		CreatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		DateUpdated DATETIME NOT NULL,
		UpdatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	);

	CREATE TABLE Favihomas.dbo.UsersAuditTrail (
		AuditTrailID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		UserModifiedID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		AuditActionID INT NOT NULL FOREIGN KEY REFERENCES AuditActions(AuditActionID),
		[Date] DATETIME NOT NULL,
		UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		Summary TEXT NOT NULL,
		Changes TEXT NULL
	);

	CREATE TABLE Favihomas.dbo.HomeOwners (
		HomeOwnerID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		FirstName VARCHAR(100) NOT NULL,
		MiddleName VARCHAR(100) NOT NULL,
		LastName VARCHAR(100) NOT NULL,
		Gender VARCHAR(1) NOT NULL,
		Street VARCHAR(100) NOT NULL,
		HouseNumber VARCHAR(10) NOT NULL,
		DateOfResidency DATETIME NULL,
		HouseHoldCount INT NOT NULL DEFAULT 0,		
		PhoneNumber VARCHAR(20) NULL,
		TelephoneNumber VARCHAR(20) NULL,
		EmailAddress VARCHAR(100) NULL,
		Status BIT NOT NULL,
		DateCreated DATETIME NOT NULL,
		CreatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		DateUpdated DATETIME NOT NULL,
		UpdatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	);

	CREATE TABLE Favihomas.dbo.HomeOwnersAuditTrail (
		AuditTrailID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		HomeOwnerID INT NOT NULL FOREIGN KEY REFERENCES HomeOwners(HomeOwnerID),
		AuditActionID INT NOT NULL FOREIGN KEY REFERENCES AuditActions(AuditActionID),
		[Date] DATETIME NOT NULL,
		UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		Summary TEXT NOT NULL,
		Changes TEXT NULL
	);

	CREATE TABLE Favihomas.dbo.DueReceipts (
		DueReceiptID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		HomeOwnerID INT NOT NULL FOREIGN KEY REFERENCES HomeOwners(HomeOwnerID),
		InvoiceNumber VARCHAR(100) NOT NULL,
		DateIssued DATETIME NOT NULL,
		Amount DECIMAL NOT NULL,
		Remarks TEXT NULL,
		ReceiptImage BINARY NULL,
		DateCreated DATETIME NOT NULL,
		CreatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		DateUpdated DATETIME NOT NULL,
		UpdatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	);

	CREATE TABLE Favihomas.dbo.DueReceiptsAuditTrail (
		AuditTrailID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		DueReceiptID INT NOT NULL FOREIGN KEY REFERENCES DueReceipts(DueReceiptID),
		AuditActionID INT NOT NULL FOREIGN KEY REFERENCES AuditActions(AuditActionID),
		[Date] DATETIME NOT NULL,
		UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		Summary TEXT NOT NULL,
		Changes TEXT NULL
	);

	CREATE TABLE Favihomas.dbo.DueReceiptDetails (
		DueReceipDetailtID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		DueReceiptID INT NOT NULL FOREIGN KEY REFERENCES DueReceipts(DueReceiptID),
		DateCovered DATETIME NOT NULL,
		Remarks TEXT NULL,
		DateCreated DATETIME NOT NULL,
		CreatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		DateUpdated DATETIME NOT NULL,
		UpdatedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	);

	CREATE TABLE Favihomas.dbo.DueReceiptDetailsAuditTrail (
		AuditTrailID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
		DueReceipDetailtID INT NOT NULL FOREIGN KEY REFERENCES DueReceiptDetails(DueReceipDetailtID),
		AuditActionID INT NOT NULL FOREIGN KEY REFERENCES AuditActions(AuditActionID),
		[Date] DATETIME NOT NULL,
		UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
		Summary TEXT NOT NULL,
		Changes TEXT NULL
	);
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH
