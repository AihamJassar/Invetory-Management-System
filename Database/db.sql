-- ==========================================
-- قاعدة البيانات: InventoryDB
-- ==========================================
CREATE DATABASE IF NOT EXISTS InventoryDB;
USE InventoryDB;

-- ==========================================
-- جدول المستخدمين: users
-- ==========================================
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- بيانات تجريبية للمستخدمين
INSERT INTO users (username, password_hash, role) VALUES
('admin', 'adminhashedpassword', 'Admin'),
('user1', 'user1hashedpassword', 'User');

-- ==========================================
-- جدول العملاء: customers
-- ==========================================
CREATE TABLE IF NOT EXISTS customers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    contact VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- بيانات تجريبية للعملاء
INSERT INTO customers (name, contact) VALUES
('Ali Ahmed', 'ali@example.com'),
('Sara Mohammed', 'sara@example.com');

-- ==========================================
-- جدول الموردين: suppliers
-- ==========================================
CREATE TABLE IF NOT EXISTS suppliers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    contact VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- بيانات تجريبية للموردين
INSERT INTO suppliers (name, contact) VALUES
('Supplier A', 'suppliera@example.com'),
('Supplier B', 'supplierb@example.com');

-- ==========================================
-- جدول المنتجات: products
-- ==========================================
CREATE TABLE IF NOT EXISTS products (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category VARCHAR(50),
    quantity INT DEFAULT 0,
    price DECIMAL(10,2) DEFAULT 0.00,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- بيانات تجريبية للمنتجات
INSERT INTO products (name, category, quantity, price) VALUES
('Laptop', 'Electronics', 10, 1200.00),
('Mouse', 'Electronics', 50, 25.50),
('Chair', 'Furniture', 20, 75.00);
