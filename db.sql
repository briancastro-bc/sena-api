CREATE SCHEMA db_api_sena;
USE db_api_sena;

CREATE TABLE IF NOT EXISTS customers(
    uid VARCHAR(36) NOT NULL PRIMARY KEY,
    name CHAR(40) NOT NULL,
    last_name CHAR(60) NOT NULL,
    identity CHAR(15) NOT NULL
);

CREATE TABLE IF NOT EXISTS invoices(
    code CHAR(10) NOT NULL PRIMARY KEY,
    customer_uid VARCHAR(36) NULL,
    datetime TIMESTAMP NULL DEFAULT current_timestamp
);

CREATE TABLE IF NOT EXISTS invoices_details(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    invoice_code CHAR(10) NULL,
    description VARCHAR(200) NOT NULL,
    value FLOAT NOT NULL
);

ALTER TABLE invoices ADD FOREIGN KEY(customer_uid) REFERENCES customers(uid);
ALTER TABLE invoices_details ADD FOREIGN KEY(invoice_code) REFERENCES invoices(code);