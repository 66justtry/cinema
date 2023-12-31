--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4
-- Dumped by pg_dump version 15.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;
--
-- Name: cinemadb; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE cinemadb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Ukrainian_Ukraine.1251';


ALTER DATABASE cinemadb OWNER TO postgres;

\connect cinemadb

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Halls; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Halls" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Info" text NOT NULL
);


ALTER TABLE public."Halls" OWNER TO postgres;

--
-- Name: Halls_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Halls" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Halls_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Movies; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Movies" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Age" integer NOT NULL,
    "PhotoUrl" text NOT NULL,
    "Year" integer NOT NULL,
    "NameOriginal" text NOT NULL,
    "Director" text NOT NULL,
    "Genre" text NOT NULL,
    "Duration" integer NOT NULL,
    "Country" text NOT NULL,
    "Actors" text NOT NULL,
    "Info" text NOT NULL
);


ALTER TABLE public."Movies" OWNER TO postgres;

--
-- Name: Movies_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Movies" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Movies_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: OrderSeats; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrderSeats" (
    "Id" integer NOT NULL,
    "IdOrder" integer NOT NULL,
    "IdSeat" integer NOT NULL
);


ALTER TABLE public."OrderSeats" OWNER TO postgres;

--
-- Name: OrderSeats_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."OrderSeats" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."OrderSeats_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Orders" (
    "Id" integer NOT NULL,
    "IdSession" integer NOT NULL,
    "Phone" text NOT NULL,
    "Sum" integer NOT NULL
);


ALTER TABLE public."Orders" OWNER TO postgres;

--
-- Name: Orders_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Orders" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Orders_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: SeatTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SeatTypes" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Info" text NOT NULL
);


ALTER TABLE public."SeatTypes" OWNER TO postgres;

--
-- Name: SeatTypes_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."SeatTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."SeatTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Seats; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Seats" (
    "Id" integer NOT NULL,
    "IdHall" integer NOT NULL,
    "IdSeatType" integer NOT NULL,
    "Row" integer NOT NULL,
    "Place" integer NOT NULL
);


ALTER TABLE public."Seats" OWNER TO postgres;

--
-- Name: Seats_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Seats" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Seats_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: SessionSeatTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SessionSeatTypes" (
    "Id" integer NOT NULL,
    "IdSeatType" integer NOT NULL,
    "IdSession" integer NOT NULL,
    "Price" integer NOT NULL
);


ALTER TABLE public."SessionSeatTypes" OWNER TO postgres;

--
-- Name: SessionSeatTypes_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."SessionSeatTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."SessionSeatTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Sessions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sessions" (
    "Id" integer NOT NULL,
    "IdMovie" integer NOT NULL,
    "IdHall" integer NOT NULL,
    "IdVideoType" integer NOT NULL,
    "DateTime" timestamp without time zone NOT NULL
);


ALTER TABLE public."Sessions" OWNER TO postgres;

--
-- Name: Sessions_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Sessions" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Sessions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: VideoTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VideoTypes" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Info" text NOT NULL
);


ALTER TABLE public."VideoTypes" OWNER TO postgres;

--
-- Name: VideoTypes_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."VideoTypes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."VideoTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: Halls; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Halls" ("Id", "Name", "Info") FROM stdin;
1	Зал 1	Основной зал
2	Зал 2	Основной зал
\.


--
-- Data for Name: Movies; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Movies" ("Id", "Name", "Age", "PhotoUrl", "Year", "NameOriginal", "Director", "Genre", "Duration", "Country", "Actors", "Info") FROM stdin;
2	Зоряні війни: Пробудження сили	12	https://multiplex.ua/images/HO00000010/03/714530ee18e75cd01eb0613b251eda90.jpeg	2015	Star Wars: Episode VII - The Force Awakens	Джей Джей Абрамс	Фантастика, Фентезі	136	США	Джон Бойега, Дейзі Рідлі, Оскар Айзек	Хай буде з вами сила! Продовження епічної і класичної саги в ще більш масштабному форматі. Дія відбувається через 30 років після «Повернення Джедая». На планети знову насувається небезпека: Сила пробуджується, і ті, кому вона підвладна, хочуть використовувати її в особистих цілях. Наближається нова міжгалактична війна.
3	Ілюзія обману 2	12	https://multiplex.ua/images/HO00000196/03/69033528fe3008d87bf97a7bd211d5b1.jpeg	2016	Now You See Me 2	Джон М. Чу	Детектив, Трилер	129	США	Ліззі Каплан, Деніел Редкліфф, Марк Руффало	Для затримання банди всесвітньо відомих фокусників, які під час своїх виступів проводять свої "брудні справи", ФБР кидає своїх кращих співробітників.
1	Загін самогубців	16	https://multiplex.ua/images/HO00000239/03/825b1dee9d7e9006d4aa09e83722108c.jpeg	2016	Suicide Squad	Девід Ейр	Бойовик, Фентезі	123	США	Марго Роббі, Вілл Сміт, Джаред Лето	Уряд вирішує дати команді суперлиходіїв шанс спокутувати гріхи. Підступ у тому, що їм доручають місію, де вони, найімовірніше, загинуть.
4	Фантастичні звірі та де їх шукати	12	https://multiplex.ua/images/HO00000256/03/dc8848989d59cdaa873ede72a5706aae.jpg	2016	Fantastic Beasts and Where to Find Them	Девід Йетс	Фентезі, Пригоди	132	США	Езра Міллер, Едді Редмейн, Колін Фаррелл	Перший фільм з майбутньої трилогії «Фантастичні звірі та де їх шукати» розповість про яскраві пригоди Ньюта Скамандера – відомого письменника та дослідника, який у своєму підручнику для учнів Гогвартсу описав багато химерних незвичайних тварин. Дія розгортається в 20-х роках ХХ століття у Нью-Йорку, за 70 років до того, як поріг Школи чародійства та магії переступить маленький Гаррі Поттер.
\.


--
-- Data for Name: OrderSeats; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."OrderSeats" ("Id", "IdOrder", "IdSeat") FROM stdin;
1	1	5
2	1	6
3	2	10
4	3	13
5	3	14
6	4	4
7	4	14
8	5	11
9	6	19
10	7	9
11	7	15
12	8	2
13	8	3
14	9	18
15	9	8
16	9	4
\.


--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Orders" ("Id", "IdSession", "Phone", "Sum") FROM stdin;
1	1	380939045883	300
2	1	380504467993	150
3	1	380505558332	300
4	10	380984752357	240
5	10	380425687458	120
6	10	380556987310	200
7	10	380997853300	240
8	6	380504568002	280
9	1	380895687458	550
\.


--
-- Data for Name: SeatTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."SeatTypes" ("Id", "Name", "Info") FROM stdin;
1	Стандарт	Стандарт
2	Lux	Lux
3	Chill	Chill
\.


--
-- Data for Name: Seats; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Seats" ("Id", "IdHall", "IdSeatType", "Row", "Place") FROM stdin;
1	1	1	1	1
2	1	1	1	2
3	1	1	1	3
4	1	1	1	4
5	1	1	1	5
6	1	1	1	6
7	1	1	1	7
8	1	1	1	8
9	1	1	2	1
10	1	1	2	2
11	1	1	2	3
12	1	1	2	4
13	1	1	2	5
14	1	1	2	6
15	1	1	2	7
16	1	1	2	8
17	1	2	3	1
18	1	2	3	2
19	1	2	3	3
20	1	2	3	4
\.


--
-- Data for Name: SessionSeatTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."SessionSeatTypes" ("Id", "IdSeatType", "IdSession", "Price") FROM stdin;
1	1	1	150
2	2	1	250
3	2	2	230
4	1	2	130
5	1	3	200
6	2	3	280
7	1	4	170
8	2	4	240
9	1	5	140
10	2	5	210
11	1	6	140
12	2	6	220
13	1	7	160
14	2	7	250
15	1	8	170
16	2	8	260
17	1	9	120
18	2	9	200
19	1	10	120
20	2	10	200
21	1	11	150
22	2	11	250
\.


--
-- Data for Name: Sessions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sessions" ("Id", "IdMovie", "IdHall", "IdVideoType", "DateTime") FROM stdin;
1	1	1	1	2023-12-28 22:00:00
2	1	1	1	2023-12-28 19:00:00
3	1	1	1	2023-12-29 15:30:00
4	1	1	1	2023-12-29 17:00:00
5	1	1	1	2023-12-29 18:30:00
6	2	1	1	2023-12-29 18:30:00
7	2	1	1	2023-12-29 20:00:00
8	3	1	2	2023-12-30 16:00:00
9	3	1	2	2023-12-30 19:30:00
10	4	1	1	2023-12-30 17:30:00
11	4	1	1	2023-12-30 21:00:00
\.


--
-- Data for Name: VideoTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VideoTypes" ("Id", "Name", "Info") FROM stdin;
1	2D	2D
2	3D	3D
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20231201170436_first migration	7.0.0
20231201194648_timestamp-change	7.0.0
\.


--
-- Name: Halls_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Halls_Id_seq"', 2, true);


--
-- Name: Movies_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Movies_Id_seq"', 4, true);


--
-- Name: OrderSeats_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrderSeats_Id_seq"', 16, true);


--
-- Name: Orders_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Orders_Id_seq"', 9, true);


--
-- Name: SeatTypes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."SeatTypes_Id_seq"', 3, true);


--
-- Name: Seats_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Seats_Id_seq"', 20, true);


--
-- Name: SessionSeatTypes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."SessionSeatTypes_Id_seq"', 22, true);


--
-- Name: Sessions_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Sessions_Id_seq"', 11, true);


--
-- Name: VideoTypes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."VideoTypes_Id_seq"', 3, true);


--
-- Name: Halls PK_Halls; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Halls"
    ADD CONSTRAINT "PK_Halls" PRIMARY KEY ("Id");


--
-- Name: Movies PK_Movies; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Movies"
    ADD CONSTRAINT "PK_Movies" PRIMARY KEY ("Id");


--
-- Name: OrderSeats PK_OrderSeats; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderSeats"
    ADD CONSTRAINT "PK_OrderSeats" PRIMARY KEY ("Id");


--
-- Name: Orders PK_Orders; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");


--
-- Name: SeatTypes PK_SeatTypes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SeatTypes"
    ADD CONSTRAINT "PK_SeatTypes" PRIMARY KEY ("Id");


--
-- Name: Seats PK_Seats; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Seats"
    ADD CONSTRAINT "PK_Seats" PRIMARY KEY ("Id");


--
-- Name: SessionSeatTypes PK_SessionSeatTypes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SessionSeatTypes"
    ADD CONSTRAINT "PK_SessionSeatTypes" PRIMARY KEY ("Id");


--
-- Name: Sessions PK_Sessions; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT "PK_Sessions" PRIMARY KEY ("Id");


--
-- Name: VideoTypes PK_VideoTypes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VideoTypes"
    ADD CONSTRAINT "PK_VideoTypes" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_OrderSeats_IdOrder; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrderSeats_IdOrder" ON public."OrderSeats" USING btree ("IdOrder");


--
-- Name: IX_OrderSeats_IdSeat; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrderSeats_IdSeat" ON public."OrderSeats" USING btree ("IdSeat");


--
-- Name: IX_Orders_IdSession; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Orders_IdSession" ON public."Orders" USING btree ("IdSession");


--
-- Name: IX_Seats_IdHall; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Seats_IdHall" ON public."Seats" USING btree ("IdHall");


--
-- Name: IX_Seats_IdSeatType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Seats_IdSeatType" ON public."Seats" USING btree ("IdSeatType");


--
-- Name: IX_SessionSeatTypes_IdSeatType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_SessionSeatTypes_IdSeatType" ON public."SessionSeatTypes" USING btree ("IdSeatType");


--
-- Name: IX_SessionSeatTypes_IdSession; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_SessionSeatTypes_IdSession" ON public."SessionSeatTypes" USING btree ("IdSession");


--
-- Name: IX_Sessions_IdHall; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sessions_IdHall" ON public."Sessions" USING btree ("IdHall");


--
-- Name: IX_Sessions_IdMovie; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sessions_IdMovie" ON public."Sessions" USING btree ("IdMovie");


--
-- Name: IX_Sessions_IdVideoType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sessions_IdVideoType" ON public."Sessions" USING btree ("IdVideoType");


--
-- Name: OrderSeats FK_OrderSeats_Orders_IdOrder; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderSeats"
    ADD CONSTRAINT "FK_OrderSeats_Orders_IdOrder" FOREIGN KEY ("IdOrder") REFERENCES public."Orders"("Id") ON DELETE CASCADE;


--
-- Name: OrderSeats FK_OrderSeats_Seats_IdSeat; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderSeats"
    ADD CONSTRAINT "FK_OrderSeats_Seats_IdSeat" FOREIGN KEY ("IdSeat") REFERENCES public."Seats"("Id") ON DELETE CASCADE;


--
-- Name: Orders FK_Orders_Sessions_IdSession; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_Sessions_IdSession" FOREIGN KEY ("IdSession") REFERENCES public."Sessions"("Id") ON DELETE CASCADE;


--
-- Name: Seats FK_Seats_Halls_IdHall; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Seats"
    ADD CONSTRAINT "FK_Seats_Halls_IdHall" FOREIGN KEY ("IdHall") REFERENCES public."Halls"("Id") ON DELETE CASCADE;


--
-- Name: Seats FK_Seats_SeatTypes_IdSeatType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Seats"
    ADD CONSTRAINT "FK_Seats_SeatTypes_IdSeatType" FOREIGN KEY ("IdSeatType") REFERENCES public."SeatTypes"("Id") ON DELETE CASCADE;


--
-- Name: SessionSeatTypes FK_SessionSeatTypes_SeatTypes_IdSeatType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SessionSeatTypes"
    ADD CONSTRAINT "FK_SessionSeatTypes_SeatTypes_IdSeatType" FOREIGN KEY ("IdSeatType") REFERENCES public."SeatTypes"("Id") ON DELETE CASCADE;


--
-- Name: SessionSeatTypes FK_SessionSeatTypes_Sessions_IdSession; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SessionSeatTypes"
    ADD CONSTRAINT "FK_SessionSeatTypes_Sessions_IdSession" FOREIGN KEY ("IdSession") REFERENCES public."Sessions"("Id") ON DELETE CASCADE;


--
-- Name: Sessions FK_Sessions_Halls_IdHall; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT "FK_Sessions_Halls_IdHall" FOREIGN KEY ("IdHall") REFERENCES public."Halls"("Id") ON DELETE CASCADE;


--
-- Name: Sessions FK_Sessions_Movies_IdMovie; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT "FK_Sessions_Movies_IdMovie" FOREIGN KEY ("IdMovie") REFERENCES public."Movies"("Id") ON DELETE CASCADE;


--
-- Name: Sessions FK_Sessions_VideoTypes_IdVideoType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT "FK_Sessions_VideoTypes_IdVideoType" FOREIGN KEY ("IdVideoType") REFERENCES public."VideoTypes"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

