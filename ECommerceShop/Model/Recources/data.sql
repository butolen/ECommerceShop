-- Leeren der abhängigen Tabellen in richtiger Reihenfolge
DELETE FROM reviews;
DELETE FROM products;
DELETE FROM users;
ALTER TABLE products AUTO_INCREMENT = 1;

-- Produkte mit product_id 1–20 explizit einfügen
INSERT INTO products (product_id, name, price, category, instock, image, description)
VALUES
    (1, 'Hexagon Hantel Set', 799.00, 'Hanteln', 35, 'images/hexagon_hantel.jpg', 'Solide Gummi-Hanteln mit Hex-Form für sicheres Training.'),
    (2, 'Kabelzug Station', 1649.00, 'Geräte', 10, 'images/kabelzug_station.jpg', 'Multifunktionale Kabelzugstation für Oberkörpertraining.'),
    (3, 'Langhantel Set 100kg', 899.00, 'Hanteln', 15, 'images/langhantel_set.jpg', 'Langhantel mit 100kg Gewichtsscheiben, ideal für Krafttraining.'),
    (4, 'Kurzhantel Set 2–30kg', 1349.00, 'Hanteln', 25, 'images/kurzhantel_set.jpg', 'Kurzhantel-Set mit variabler Gewichtsauswahl von 2 bis 30 kg.'),
    (5, 'Rudergerät ProX', 1199.00, 'Geräte', 8, 'images/rudergeraet.jpg', 'Professionelles Rudergerät mit Magnetbremse und LCD-Anzeige.'),
    (6, 'Power Rack Pro', 1499.00, 'Geräte', 12, 'images/power_rack.jpg', 'Massives Power Rack mit Sicherheitsstreben, Klimmzugstange und Dip-Griffen.'),
    (7, 'Kettlebell Set 4–32kg', 599.00, 'Zubehör', 40, 'images/kettlebell_set.jpg', 'Set aus 9 hochwertigen Kettlebells von 4 bis 32kg. Sehr gut für effektives Krafttraining'),
    (8, 'Klimmzugstange Decke', 149.00, 'Zubehör', 50, 'images/klimmzug_decke.jpg', 'Robuste Decken-Klimmzugstange für zuhause oder Studio.'),
    (9, 'Sandsack Boxtraining 40kg', 229.00, 'Zubehör', 20, 'images/sandsack_box.jpg', 'Boxsack mit Aufhängung und 40kg Gewicht für Schlagkrafttraining.'),
    (10, 'Gymnastikmatte Pro', 49.90, 'Zubehör', 80, 'images/gymnastikmatte.jpg', 'Rutschfeste, gepolsterte Fitnessmatte – 190x60x1,5 cm.'),
    (11, 'Balance Board Pro', 89.00, 'Zubehör', 35, 'images/balance_board.jpg', 'Trainingsboard zur Verbesserung von Gleichgewicht und Koordination.'),
    (12, 'Dip Station Deluxe', 219.00, 'Geräte', 18, 'images/dip_station.jpg', 'Stabile Dip-Station für Trizeps- und Oberkörpertraining.'),
    (13, 'Beinpresse 2000', 2399.00, 'Geräte', 5, 'images/beinpresse.jpg', 'Professionelle Beinpresse mit verstellbarem Sitz und hoher Belastbarkeit.'),
    (14, 'Stepper Cardio Fit', 499.00, 'Geräte', 14, 'images/stepper.jpg', 'Kompakter Stepper für effektives Herz-Kreislauf-Training.'),
    (15, 'Medizinball Set 1–10kg', 179.00, 'Zubehör', 22, 'images/medizinball_set.jpg', 'Set aus 5 Medizinbällen mit Gewichten von 1 bis 10kg.'),
    (16, 'Resistance Bands Set', 39.90, 'Zubehör', 60, 'images/resistance_bands.jpg', 'Set mit 5 Widerstandsbändern in verschiedenen Stärken.'),
    (17, 'Schlingentrainer Pro', 119.00, 'Zubehör', 30, 'images/schlingentrainer.jpg', 'Stabiler Schlingentrainer für Ganzkörpertraining an Türen oder Stangen.'),
    (18, 'Schnellverschluss Hantelclips', 19.90, 'Zubehör', 100, 'images/hantelclips.jpg', 'Sichere Hantelclips für schnellen Gewichtswechsel bei Langhanteln.'),
    (19, 'Trizepsseil Zugturm', 29.90, 'Zubehör', 70, 'images/trizepsseil.jpg', 'Robustes Zugseil mit Griff für Trizeps-Übungen an Kabelzügen.'),
    (20, 'Ergonomische Trainingsbank', 299.00, 'Geräte', 9, 'images/trainingsbank.jpg', 'Verstellbare Bank für Flach-, Schräg- und Negativbankdrücken.');

-- Benutzer einfügen (müssen vor den Reviews existieren!)
INSERT INTO users (username, email, password)
VALUES
    ('h.muster', 'h.muster@example.com', '$2a$11$B8sFD9DeouC4UQl8aDnFeugbshdv'),
    ('d.til', 'd.til@example.com', '$2a$11$B8sFD9DeouC4UQl8aDnFsfgdsgsda'),
    ('a.gruen', 'a.gruen@example.com', '$2a$11$B8sFD9DeouC4UQl8aDnFeuerewsacxxyvxyv');

-- Reviews mit productid 1–20 und gültigen Usernames
INSERT INTO reviews (reviewid, rating, productid, text, username)
VALUES
    (1, 5, 1, 'Beste Wahl bisher', 'h.muster'),
    (2, 2, 2, 'War ok, aber könnte besser sein', 'h.muster'),
    (3, 2, 3, 'Nicht das, was ich erwartet habe', 'h.muster'),
    (4, 5, 4, 'Empfehlung!', 'h.muster'),
    (5, 4, 5, 'Bin zufrieden', 'h.muster'),
    (6, 5, 6, 'Top Produkt!', 'h.muster'),
    (7, 5, 7, 'Top Produkt!', 'h.muster'),
    (8, 2, 8, 'Nicht das, was ich erwartet habe', 'h.muster'),
    (9, 5, 9, 'Gute Qualität', 'h.muster'),
    (10, 2, 10, 'War ok, aber könnte besser sein', 'h.muster'),
    (11, 2, 11, 'War ok, aber könnte besser sein', 'h.muster'),
    (12, 1, 12, 'Hat nicht funktioniert', 'h.muster'),
    (13, 5, 13, 'Top Produkt!', 'h.muster'),
    (14, 2, 14, 'Nicht das, was ich erwartet habe', 'h.muster'),
    (15, 5, 15, 'Gute Qualität', 'h.muster'),
    (16, 4, 16, 'Bin zufrieden', 'h.muster'),
    (17, 2, 17, 'Nicht das, was ich erwartet habe', 'h.muster'),
    (18, 5, 18, 'Top Produkt!', 'h.muster'),
    (19, 2, 19, 'War ok, aber könnte besser sein', 'h.muster'),
    (20, 5, 20, 'Top Leistung', 'h.muster'),
    (21, 5, 1, 'Top Produkt!', 'd.til'),
    (22, 2, 2, 'War ok, aber könnte besser sein', 'd.til'),
    (23, 4, 3, 'Ganz gut für den Preis', 'd.til'),
    (24, 2, 4, 'Nicht das, was ich erwartet habe', 'd.til'),
    (25, 5, 5, 'Empfehlung!', 'd.til'),
    (26, 4, 6, 'Ganz gut für den Preis', 'd.til'),
    (27, 4, 7, 'Bin zufrieden', 'd.til'),
    (28, 5, 8, 'Top Produkt!', 'd.til'),
    (29, 2, 9, 'War ok, aber könnte besser sein', 'd.til'),
    (30, 1, 10, 'Hat nicht funktioniert', 'd.til'),
    (31, 2, 11, 'Nicht das, was ich erwartet habe', 'd.til'),
    (32, 5, 12, 'Top Leistung', 'd.til'),
    (33, 5, 13, 'Gute Qualität', 'd.til'),
    (34, 4, 14, 'Bin zufrieden', 'd.til'),
    (35, 5, 15, 'Empfehlung!', 'd.til'),
    (36, 2, 16, 'War ok, aber könnte besser sein', 'd.til'),
    (37, 4, 17, 'Ganz gut für den Preis', 'd.til'),
    (38, 5, 18, 'Beste Wahl bisher', 'd.til'),
    (39, 5, 19, 'Top Produkt!', 'd.til'),
    (40, 5, 20, 'Top Leistung', 'd.til'),
    (41, 4, 1, 'Ganz gut für den Preis', 'a.gruen'),
    (42, 5, 2, 'Gute Qualität', 'a.gruen'),
    (43, 2, 3, 'Nicht das, was ich erwartet habe', 'a.gruen'),
    (44, 4, 4, 'Bin zufrieden', 'a.gruen'),
    (45, 1, 5, 'Hat nicht funktioniert', 'a.gruen'),
    (46, 5, 6, 'Empfehlung!', 'a.gruen'),
    (47, 5, 7, 'Top Produkt!', 'a.gruen'),
    (48, 4, 8, 'Ganz gut für den Preis', 'a.gruen'),
    (49, 2, 9, 'War ok, aber könnte besser sein', 'a.gruen'),
    (50, 5, 10, 'Top Produkt!', 'a.gruen'),
    (51, 4, 11, 'Bin zufrieden', 'a.gruen'),
    (52, 5, 12, 'Top Leistung', 'a.gruen'),
    (53, 2, 13, 'War ok, aber könnte besser sein', 'a.gruen'),
    (54, 2, 14, 'Nicht das, was ich erwartet habe', 'a.gruen'),
    (55, 5, 15, 'Gute Qualität', 'a.gruen'),
    (56, 1, 16, 'Hat nicht funktioniert', 'a.gruen'),
    (57, 5, 17, 'Empfehlung!', 'a.gruen'),
    (58, 4, 18, 'Ganz gut für den Preis', 'a.gruen'),
    (59, 4, 19, 'Bin zufrieden', 'a.gruen'),
    (60, 5, 20, 'Top Produkt!', 'a.gruen');
DELETE FROM administrators;
INSERT INTO administrators(username, email, password)
VALUES('m.butolen','m.butolen@htlkrems.at','$2a$11$B8sFD9DeouC4UQl8aDnFeuK2YKmseKqa35OS830JXnilJ8UzDJ4vK');

