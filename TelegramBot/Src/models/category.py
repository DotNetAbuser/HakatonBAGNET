from sqlalchemy import Column, String, Integer, Boolean

from TelegramBot.Src.dataBase.dbcore import Base


class Category(Base):
    __tablename__ = 'categories'

    category_id = Column(Integer, primary_key=True)
    title = Column(String, nullable=False)

    def __repr__(self):
        return f"<Category(category_id={self.category_id}, title='{self.title}')>"
