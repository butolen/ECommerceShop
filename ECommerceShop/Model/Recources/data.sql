DELETE FROM products;
INSERT INTO products (name, price, category, instock, image, description)
VALUES
    ('Hexagon Hantel Set', 799.00, 'Hanteln', 30, 'images/hexagon_hantel.jpg', 'Solide Gummi-Hanteln mit Hex-Form für sicheres Training.'),
    ('Kabelzug Station', 164.00, 'Geräte', 10, 'images/kabelzug_station.jpg', 'Multifunktionale Kabelzugstation für Oberkörpertraining.'),
    ('Langhantel Set 100kg', 899.00, 'Hanteln', 15, 'images/langhantel_set.jpg', 'Langhantel mit 100kg Gewichtsscheiben, ideal für Krafttraining.'),
    ('Kurzhantel Set 2–30kg', 149.00, 'Hanteln', 25, 'images/kurzhantel_set.jpg', 'Kurzhantel-Set mit variabler Gewichtsauswahl von 2 bis 30 kg.'),
    ('Rudergerät ProX', 199.00, 'Geräte', 8, 'images/rudergeraet.jpg', 'Professionelles Rudergerät mit Magnetbremse und LCD-Anzeige.'),
    ('Power Rack Pro', 199.00, 'Geräte', 12, 'images/power_rack.jpg', 'Massives Power Rack mit Sicherheitsstreben, Klimmzugstange und Dip-Griffen.'),
    ('Kettlebell Set 4–32kg', 599.00, 'Zubehör', 40, 'images/kettlebell_set.jpg', 'Set aus 9 hochwertigen Kettlebells von 4 bis 32kg.'),
    ('Klimmzugstange Decke', 149.00, 'Zubehör', 50, 'images/klimmzug_decke.jpg', 'Robuste Decken-Klimmzugstange für zuhause oder Studio.'),
    ('Sandsack Boxtraining 40kg', 229.00, 'Zubehör', 20, 'images/sandsack_box.jpg', 'Boxsack mit Aufhängung und 40kg Gewicht für Schlagkrafttraining.'),
    ('Gymnastikmatte Pro', 49.90, 'Zubehör', 80, 'images/gymnastikmatte.jpg', 'Rutschfeste, gepolsterte Fitnessmatte – 190x60x1,5 cm.');

DELETE FROM administrators;
INSERT INTO administrators(username, email, password) 
VALUES('m.butolen','m.butolen@htlkrems.at','butolen123456');


INSERT INTO administrators(username, email, password)
VALUES('n.goll','n.goll@htlkrems.at','goll123456');



INSERT INTO administrators(username, email, password)
VALUES('d.thielman','d.thielman@htlkrems.at','thielman123456');