from os import path
from datetime import datetime

from TelegramBot.Src.settings.config import DATABASE_URL
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from TelegramBot.Src.dataBase.dbcore import Base


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
