import json

import requests
from aiogram import F
from aiogram import types

from TelegramBot.Src.KeyBoards import kbn, kb1, kbn2, kb2, kb0, ask_question
from TelegramBot.Src.ManagerAPI.get_request import get_response, deserializer

from aiogram.fsm.context import FSMContext

temp_id = 1

async def handle_my_vopr(callback: types.CallbackQuery):
    user_id = callback.from_user.id

    api_url = f'http://localhost:8001/api/Question/get-paginated-by-user-id/{user_id}?pageNumber=1&pageSize=100'

    response = deserializer(get_response(api_url).text)
    question_list = response['data']['list']
    message_for_user = ''
    for question in question_list:
        message_for_user += (
            f'\nКатегория: {question["categoryTitle"]}.'
            f'\nТекст вопроса:\n«{question["questionContent"]}»'
            f'\nНаграда: {question["correctPointsCount"]} '
            f'Штраф: {question["incorrectPointsCount"]}\n'
        )

    await callback.message.answer(f"Ваши вопросы:\n {message_for_user}", reply_markup=kbn.as_markup())
    await callback.message.delete()


async def handle_my_otv(callback: types.CallbackQuery):
    await callback.message.answer("Ожидайте ответ от БД по вашим ответам", reply_markup=kbn.as_markup())
    await callback.message.delete()


async def handle_my_score(callback: types.CallbackQuery):
    api_url = 'http://localhost:8001/api/User/get-paginted-by-rating?pageNumber=1&pageSize=10'
    response = get_response(url=api_url)
    result = deserializer(response.text)

    rating_list = result['data']['list']
    output_string = ''
    count = 1

    for item in rating_list:
        output_string += f'{count}. {item["first_name"]} {item["last_name"]}, очков - {item["points_counts"]} \n'
        count += 1

    if not result['succeeded']:
        await callback.message.answer("Произошла ошибка", reply_markup=kbn.as_markup())
        await callback.message.delete()
        return

    await callback.message.answer(output_string, reply_markup=kbn.as_markup())
    await callback.message.delete()


async def handle_forum(callback: types.CallbackQuery):
    await callback.message.answer("Здесь вы можете задать вопрос или ответить на него:", reply_markup=kb1.as_markup())
    await callback.message.delete()


async def handle_back(callback: types.CallbackQuery):
    await callback.message.answer(
        f"Студент {callback.from_user.username}, Добро Пожаловать!"
        "\nВы можете узнать:\nКакие вопросы вы задавали ранее,\nНа какие вопросы вы уже ответили,\nСвои баллы за ответы,\nЗадать вопрос или ответить на него",
        reply_markup=kb0.as_markup()  # Используем клавиатуру с кнопками "форум" и "общий рейтинг"
    )
    await callback.message.delete()


async def handle_vopr(callback: types.CallbackQuery):
    await callback.message.answer("Выберите тему вопроса:", reply_markup=ask_question.as_markup())
    await callback.message.delete()


async def handle_subject_vopr(callback: types.CallbackQuery, state: FSMContext):
    await callback.message.answer("Введите ваш вопрос:")
    await callback.message.delete()


async def handle_message(message: types.Message):
    api_url = 'http://localhost:8001/api/Question'

    json_data = {
        'user_id': message.from_user.id,
        'category_id': temp_id,
        'question_content': message.text,
        'correct_points_count': 1,
        "incorrect_points_count": -1,
    }

    json_data = json.dumps(json_data)
    requests.post(api_url, data=json_data, headers={'Content-Type': 'application/json'})

    await message.answer(f"Ваше сообщение обработано!")


async def handle_otv(callback: types.CallbackQuery):
    await callback.message.answer("Выберите тему вопроса, на который хотите ответить:", reply_markup=kb2.as_markup())
    await callback.message.delete()


async def handle_subject_otv(callback: types.CallbackQuery):
    await callback.message.answer("Вопросов по выбранному предмету пока не задано", reply_markup=kbn2.as_markup())
    await callback.message.delete()


def register(dp):
    dp.callback_query.register(handle_my_vopr, F.data == 'my_vopr')
    dp.callback_query.register(handle_my_otv, F.data == 'my_otv')
    dp.callback_query.register(handle_my_score, F.data == 'my_score')
    dp.callback_query.register(handle_forum, F.data == 'forum')
    dp.callback_query.register(handle_back, F.data == 'back')
    dp.callback_query.register(handle_vopr, F.data == 'vopr')
    dp.callback_query.register(handle_subject_vopr, F.data.in_(['1', '2', '3', '4', '5']))  # Темы для вопросов
    dp.callback_query.register(handle_otv, F.data == 'otv')
    dp.callback_query.register(handle_subject_otv, F.data.in_(['v_mat', 'v_fiz', 'v_inf']))  # Темы для ответов
    dp.callback_query.register(handle_back, F.data == 'back1')
    dp.callback_query.register(handle_back, F.data == 'back2')
    dp.callback_query.register(handle_back, F.data == 'back3')
    dp.message.register(handle_message, lambda message: message.content_type == types.ContentType.TEXT)
