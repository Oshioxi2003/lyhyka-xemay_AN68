-- Migration script for Electric Bicycle Report changes
-- Run against Motobike.db (SQLite)

-- Add new columns to Brands table
ALTER TABLE Brands ADD COLUMN BrakeForceSumMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN BrakeForceSumMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN VoltageDropMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN VoltageDropMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN OverCurrentMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN OverCurrentMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueFrontMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueFrontMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueRearMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueRearMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueForkMin REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN AxleTorqueForkMax REAL DEFAULT 0;
ALTER TABLE Brands ADD COLUMN HideInspectionSection INTEGER DEFAULT 0;

-- Add new columns to TestVehicles table
ALTER TABLE TestVehicles ADD COLUMN CertificateNumber TEXT DEFAULT '';
ALTER TABLE TestVehicles ADD COLUMN VehicleBrandName TEXT DEFAULT '';
ALTER TABLE TestVehicles ADD COLUMN VehicleColor TEXT DEFAULT '';
ALTER TABLE TestVehicles ADD COLUMN AxleTorqueFork REAL DEFAULT 0;

-- Create ReportCounter table for sequential report numbering
CREATE TABLE IF NOT EXISTS ReportCounters (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CounterDate TEXT NOT NULL,
    Counter INTEGER NOT NULL DEFAULT 0
);
