CREATE TABLE restaurants (
    restaurant_id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    rating INTEGER DEFAULT 0,
    photo_url VARCHAR(400),
    address VARCHAR(400),
    link_to_360 VARCHAR(400),
    latitude FLOAT(8),
    longitude FLOAT(8),
    created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE helper_table (
    helper_table_id SERIAL PRIMARY KEY,
    patched_id INTEGER,
    patched_table_id INTEGER DEFAULT NULL,
    current_user_id INTEGER DEFAULT NULL
);

CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    user_name VARCHAR(255) UNIQUE NOT NULL,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    restaurant_id INTEGER REFERENCES restaurants(restaurant_id)
);

CREATE TABLE table_bookings (
    table_booking_id SERIAL PRIMARY KEY,
    restaurant_id INTEGER REFERENCES restaurants(restaurant_id),
    table_id INTEGER NOT NULL,
    x_axis FLOAT(8),
    y_axis FLOAT(8),
    z_axis FLOAT(8),
    hour_booked INTEGER,
    date_booked VARCHAR(10),
    user_id INTEGER REFERENCES users(user_id)
);

