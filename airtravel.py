"""
Model for aircraft flights
"""

class Flight:

    def __init__(self, flightNumber, aircraft):
        if not flightNumber[:2].isalpha():
            raise ValueError("No airline code in'{}'".format(flightNumber))

        if not flightNumber[:2].isupper():
            raise ValueError("Invalid airline code'{}'".format(flightNumber))

        if not(flightNumber[2:].isdigit() and int(flightNumber[2:]) <= 9999):
            raise ValueError("Invalid route number'{}'".format(flightNumber))

        self._number = flightNumber
        self._aircraft = aircraft

        rows, seats = self._aircraft.seating_plan()
        self._seating = [None] + [{letter: None for letter in seats} for _ in rows]

    def number(self):
        return self._number

    def airline(self):
        return self._number[:2]

    def aircraft_model(self):
        return self._aircraft.model()

    def _parse_seat(self, seat):

        row_numbers, seat_letters = self._aircraft.seating_plan()

        letter = seat[-1]
        if letter not in seat_letters:
            raise ValueError("Invalid seat letter {}".format(letter))
        row_text = seat[:-1]
        try:
            row = int(row_text)
        except ValueError:
            raise ValueError("Invalid seat row {}".format(row_text))

        if row not in row_numbers:
            raise ValueError("Invalid row number {}".format(letter))

        return row, letter


    def allocate_seat(self, seat, passenger):

        row, letter = self._parse_seat(seat)

        if self._seating[row][letter] is not None:
            raise ValueError("Seat {} is already occupied".format(seat))

        self._seating[row][letter] = passenger



class Aircraft:

    def __init__(self, registration, model, num_rows, num_seats_per_row):
        self._registration = registration
        self._model = model
        self._num_rows = num_rows
        self._num_seats_per_row = num_seats_per_row

    def registration(self):
        return self._registration

    def model(self):
        return self._model

    def num_rows(self):
        return self._num_rows

    def num_seats_per_row(self):
        return self._num_seats_per_row

    def seating_plan(self):
        return (range(1, self._num_rows + 1), "ABCDEFGHJK"[:self._num_seats_per_row])


"""
a = Aircraft('G-EUPT', 'Airbus A319', num_rows = 22, num_seats_per_row = 6)
"""