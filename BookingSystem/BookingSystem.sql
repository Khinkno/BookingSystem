PGDMP                     	    {            BookingSystem    12.16    12.16     $           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            %           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            &           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            '           1262    21773    BookingSystem    DATABASE     �   CREATE DATABASE "BookingSystem" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_World.1252' LC_CTYPE = 'English_World.1252';
    DROP DATABASE "BookingSystem";
                postgres    false            (           0    0    BookingSystem    DATABASE PROPERTIES     N   ALTER ROLE postgres IN DATABASE "BookingSystem" SET bytea_output TO 'escape';
                     postgres    false            �            1259    30096    UserInfo    TABLE     �   CREATE TABLE public."UserInfo" (
    userid integer NOT NULL,
    name character varying(100),
    email character varying(200),
    phno character varying(200),
    countryid smallint,
    password character varying(200)
);
    DROP TABLE public."UserInfo";
       public         heap    postgres    false            �            1259    30139    booking    TABLE     �   CREATE TABLE public.booking (
    bookingid integer NOT NULL,
    user_pid integer NOT NULL,
    classid integer NOT NULL,
    userid integer NOT NULL,
    status character varying(100),
    created_date timestamp without time zone
);
    DROP TABLE public.booking;
       public         heap    postgres    false            �            1259    21799    class    TABLE     >  CREATE TABLE public.class (
    classid integer NOT NULL,
    name character varying(100),
    countryid smallint,
    no_of_credits integer,
    available_slots integer,
    waitlist_slots integer,
    start_datetime timestamp without time zone,
    end_datetime timestamp without time zone,
    duration smallint
);
    DROP TABLE public.class;
       public         heap    postgres    false            �            1259    21809    country    TABLE     u   CREATE TABLE public.country (
    countryid smallint NOT NULL,
    name character varying(100),
    code smallint
);
    DROP TABLE public.country;
       public         heap    postgres    false            �            1259    30134    packages    TABLE       CREATE TABLE public.packages (
    pid integer NOT NULL,
    name character varying(100),
    countryid smallint,
    no_of_credits integer,
    price double precision,
    start_date timestamp without time zone,
    expired_date timestamp without time zone,
    duration smallint
);
    DROP TABLE public.packages;
       public         heap    postgres    false            �            1259    29965    user_package    TABLE       CREATE TABLE public.user_package (
    user_pid integer NOT NULL,
    userid integer,
    pid integer,
    datetime timestamp without time zone,
    isexpired boolean,
    payment character varying(100),
    available_credits integer,
    used_credits integer
);
     DROP TABLE public.user_package;
       public         heap    postgres    false                      0    30096    UserInfo 
   TABLE DATA           T   COPY public."UserInfo" (userid, name, email, phno, countryid, password) FROM stdin;
    public          postgres    false    205   �       !          0    30139    booking 
   TABLE DATA           ]   COPY public.booking (bookingid, user_pid, classid, userid, status, created_date) FROM stdin;
    public          postgres    false    207   �                 0    21799    class 
   TABLE DATA           �   COPY public.class (classid, name, countryid, no_of_credits, available_slots, waitlist_slots, start_datetime, end_datetime, duration) FROM stdin;
    public          postgres    false    202   Q                 0    21809    country 
   TABLE DATA           8   COPY public.country (countryid, name, code) FROM stdin;
    public          postgres    false    203   �                  0    30134    packages 
   TABLE DATA           r   COPY public.packages (pid, name, countryid, no_of_credits, price, start_date, expired_date, duration) FROM stdin;
    public          postgres    false    206   &                 0    29965    user_package 
   TABLE DATA           |   COPY public.user_package (user_pid, userid, pid, datetime, isexpired, payment, available_credits, used_credits) FROM stdin;
    public          postgres    false    204   �       �
           2606    30103    UserInfo UserInfo_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."UserInfo"
    ADD CONSTRAINT "UserInfo_pkey" PRIMARY KEY (userid);
 D   ALTER TABLE ONLY public."UserInfo" DROP CONSTRAINT "UserInfo_pkey";
       public            postgres    false    205            �
           2606    30143    booking booking_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_pkey PRIMARY KEY (bookingid);
 >   ALTER TABLE ONLY public.booking DROP CONSTRAINT booking_pkey;
       public            postgres    false    207            �
           2606    21803    class class_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.class
    ADD CONSTRAINT class_pkey PRIMARY KEY (classid);
 :   ALTER TABLE ONLY public.class DROP CONSTRAINT class_pkey;
       public            postgres    false    202            �
           2606    21813    country country_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.country
    ADD CONSTRAINT country_pkey PRIMARY KEY (countryid);
 >   ALTER TABLE ONLY public.country DROP CONSTRAINT country_pkey;
       public            postgres    false    203            �
           2606    30138    packages packages_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.packages
    ADD CONSTRAINT packages_pkey PRIMARY KEY (pid);
 @   ALTER TABLE ONLY public.packages DROP CONSTRAINT packages_pkey;
       public            postgres    false    206            �
           2606    29969    user_package user_package_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.user_package
    ADD CONSTRAINT user_package_pkey PRIMARY KEY (user_pid);
 H   ALTER TABLE ONLY public.user_package DROP CONSTRAINT user_package_pkey;
       public            postgres    false    204               E   x�3����������+O��wH�M���K���4��542615�4�1��8�sS�9�@$V�F�1z\\\ u�/      !   M   x�3�4B#N�ļ��N##c]C]cCC+Cs+c3=3KC.#NcN�B�����deF�V&�V��z&�\1z\\\ ��         �   x�3�4T�(R��OOTp�I,.V�v��4�42�4###c]CC]C+ ��(XB������eB�Y&�N��yy�E
��>!�
� 5|}599�	�g@1Ϙ˘�3�$�(75%3�$�L�H74F��� &�C�         )   x�3���L��M,�4�2���KO,�/J�43����� ���          �   x�3��PHL�NLOU�v��4�440 c##c]C]cC+c+=c3s�����	H���
�8M��8�s��3�&��jrr���y�V�FVF�z��@�̠���g�e��:�Yd�.F��� �m0�         ^   x��˻@@���W��;3X�UkU�M�h����T�s�ѼT��Bc2&��sǊ!�}�g(	��?�I�%���1nGF�H���I'"e
"r��(     