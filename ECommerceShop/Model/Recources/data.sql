DELETE FROM products;
ALTER TABLE products MODIFY price DECIMAL(10,2);

   
INSERT INTO products (name, price, category, instock, image, description)
VALUES
    ('Hexagon Hantel Set', 799.00, 'Hanteln', 35, 'images/hexagon_hantel.jpg', 'Solide Gummi-Hanteln mit Hex-Form für sicheres Training.'),
    ('Kabelzug Station', 1649.00, 'Geräte', 10, 'images/kabelzug_station.jpg', 'Multifunktionale Kabelzugstation für Oberkörpertraining.'),
    ('Langhantel Set 100kg', 899.00, 'Hanteln', 15, 'images/langhantel_set.jpg', 'Langhantel mit 100kg Gewichtsscheiben, ideal für Krafttraining.'),
    ('Kurzhantel Set 2–30kg', 1349.00, 'Hanteln', 25, 'images/kurzhantel_set.jpg', 'Kurzhantel-Set mit variabler Gewichtsauswahl von 2 bis 30 kg.'),
    ('Rudergerät ProX', 1199.00, 'Geräte', 8, 'images/rudergeraet.jpg', 'Professionelles Rudergerät mit Magnetbremse und LCD-Anzeige.'),
    ('Power Rack Pro', 1499.00, 'Geräte', 12, 'images/power_rack.jpg', 'Massives Power Rack mit Sicherheitsstreben, Klimmzugstange und Dip-Griffen.'),
    ('Kettlebell Set 4–32kg', 599.00, 'Zubehör', 40, 'images/kettlebell_set.jpg', 'Set aus 9 hochwertigen Kettlebells von 4 bis 32kg. Sehr gut für effektives Krafttraining'),
    ('Klimmzugstange Decke', 149.00, 'Zubehör', 50, 'images/klimmzug_decke.jpg', 'Robuste Decken-Klimmzugstange für zuhause oder Studio.'),
    ('Sandsack Boxtraining 40kg', 229.00, 'Zubehör', 20, 'images/sandsack_box.jpg', 'Boxsack mit Aufhängung und 40kg Gewicht für Schlagkrafttraining.'),
    ('Gymnastikmatte Pro', 49.90, 'Zubehör', 80, 'images/gymnastikmatte.jpg', 'Rutschfeste, gepolsterte Fitnessmatte – 190x60x1,5 cm.'),
    ('Balance Board Pro', 89.00, 'Zubehör', 35, 'images/balance_board.jpg', 'Trainingsboard zur Verbesserung von Gleichgewicht und Koordination.'),
    ('Dip Station Deluxe', 219.00, 'Geräte', 18, 'images/dip_station.jpg', 'Stabile Dip-Station für Trizeps- und Oberkörpertraining.'),
    ('Beinpresse 2000', 2399.00, 'Geräte', 5, 'images/beinpresse.jpg', 'Professionelle Beinpresse mit verstellbarem Sitz und hoher Belastbarkeit.'),
    ('Stepper Cardio Fit', 499.00, 'Geräte', 14, 'images/stepper.jpg', 'Kompakter Stepper für effektives Herz-Kreislauf-Training.'),
    ('Medizinball Set 1–10kg', 179.00, 'Zubehör', 22, 'images/medizinball_set.jpg', 'Set aus 5 Medizinbällen mit Gewichten von 1 bis 10kg.'),
    ('Resistance Bands Set', 39.90, 'Zubehör', 60, 'images/resistance_bands.jpg', 'Set mit 5 Widerstandsbändern in verschiedenen Stärken.'),
    ('Schlingentrainer Pro', 119.00, 'Zubehör', 30, 'images/schlingentrainer.jpg', 'Stabiler Schlingentrainer für Ganzkörpertraining an Türen oder Stangen.'),
    ('Schnellverschluss Hantelclips', 19.90, 'Zubehör', 100, 'images/hantelclips.jpg', 'Sichere Hantelclips für schnellen Gewichtswechsel bei Langhanteln.'),
    ('Trizepsseil Zugturm', 29.90, 'Zubehör', 70, 'images/trizepsseil.jpg', 'Robustes Zugseil mit Griff für Trizeps-Übungen an Kabelzügen.'),
    ('Ergonomische Trainingsbank', 299.00, 'Geräte', 9, 'images/trainingsbank.jpg', 'Verstellbare Bank für Flach-, Schräg- und Negativbankdrücken.');


DELETE FROM administrators;
INSERT INTO administrators(username, email, password) 
VALUES('m.butolen','m.butolen@htlkrems.at','butolen123456');


INSERT INTO administrators(username, email, password)
VALUES('n.goll','n.goll@htlkrems.at','goll123456');




INSERT INTO administrators(username, email, password)
VALUES('d.thielman','d.thielman@htlkrems.at','thielman123456');


