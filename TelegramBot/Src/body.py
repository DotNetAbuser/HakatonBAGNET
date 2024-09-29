import asyncio
import logging
from aiogram import Bot, Dispatcher, types
from settings import config
from handlers import callbacks, commands

# Настройка логирования
logging.basicConfig(level=logging.INFO)

# Инициализация бота и диспетчера
bot = Bot(token=config.TOKEN)
dp = Dispatcher()


commands.register(dp=dp)
callbacks.register(dp=dp)


async def main():
    await dp.start_polling(bot)


if __name__ == "__main__":
    asyncio.run(main())
