DELETE FROM products;

INSERT INTO products (name, price, category, instock, image, description )
VALUES
    ('iPhone 14 Pro', 19.99, 'Smartphones', 50, 'images/iphone14.jpg', 'fasfdfad'),
    ('Samsung Galaxy S23', 99.50, 'Smartphones', 35, 'images/samsung_s23.jpg','fasfdfad'),
    ('HP Laptop 15s', 79.00, 'Laptops', 20, 'images/hp15s.jpg','fasfdfad'),
    ('Bluetooth Kopfhörer', 59.99, 'Zubehör', 100, 'images/headphones.jpg','fasfdfad');

DELETE FROM administrators;
INSERT INTO administrators(username, email, password) 
VALUES('m.butolen','m.butolen@htlkrems.at','butolen123456');


INSERT INTO administrators(username, email, password)
VALUES('n.goll','n.goll@htlkrems.at','goll123456');



INSERT INTO administrators(username, email, password)
VALUES('d.thielman','d.thielman@htlkrems.at','thielman123456');