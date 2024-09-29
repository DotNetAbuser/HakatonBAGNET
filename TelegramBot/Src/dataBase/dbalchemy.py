from os import path
from datetime import datetime

from TelegramBot.Src.settings.config import DATABASE_URL
from sqlalchemy import create_engine, MetaData, Column, Integer
from sqlalchemy.orm import sessionmaker

from sqlalchemy import create_engine, MetaData, Table, select

class Singleton(type):
    def __init__(cls, names, bases, attrs, **kwargs):
        super().__init__(names, bases, attrs)
        cls.__instance = None

    def __call__(cls, *args, **kwargs):
        if cls.__instance is None:
            cls.__instance = super().__call__(*args, **kwargs)
        return cls.__instance


class DBManager(metaclass=Singleton):
    def __init__(self):
        self.engine = create_engine(DATABASE_URL)
        session = sessionmaker(bind=self.engine)
        self._session = session()

    def close(self):
        """
        Закрытие сессии
        """
        self._session.close()

    def get_all_models(self):
        metadata = MetaData()
        metadata.reflect(bind=self.engine)

        print("Существующие таблицы в базе данных:")

        for table_name in metadata.tables.keys():
            print(table_name)
            self.fetch_data_from_table(table_name)

    def fetch_data_from_table(self, table_name):
        # Определяем таблицу
        table = Table(table_name, MetaData(), autoload_with=self.engine)

        # Выполняем запрос для получения всех данных из таблицы
        with self.engine.connect() as connection:
            query = select(table)
            result = connection.execute(query)

            # Выводим данные
            print(f"Данные из таблицы {table_name}:")
            for row in result:
                print(row)