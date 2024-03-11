# Hlídač rozpočtů SRS

Verze: 0.0.1

Shrnutí verze: První návrh SRS vytvořený před zahájením zpracování projektu. Zaměrujese na technickou stránku.

Datum vytvoření: 11.3.2023

Autor: Kryštof Kubín
<br/><br/>

## 1. Úvod

<br/>

### 1.1 Účel

Tato aplikace má. účel sloužit jako spůsob uchovávání informací o financích, jejich distribuci, volnosti a dalších údajů.
<br/><br/>

### 1.2 Konvence dokumentu

<br/>

**Formáty**

_Dokument_ jsou ve formátu markdown (md).

_Nadpis dokumentu_ jsou ve formátu H1.

_Nadpisy sekcí_ jsou ve formátu H2.

_Nadpisy podsekcí_ jsou ve formátu H3.

_Běžný text_ je napsán bez formátování

_Důležité pojmy_ jsou vyznačené kurzivou.

<br/>

**Řádkování**

Mezi _sekcemi_ jsou dva prázdné rádky.

Před názvem _podsekce_ je jeden prázdný řádek.

V případě v rozlišnosti témat v podeskcích jsou jednotlivé témata pojmenována tučným píšmem a nad jejich nadpisem je jedna mezara.
<br/><br/>

### 1.3 Pro koho je dokument uřený

Dokument je uřený pro vývojáře projektu.
<br/><br/>

### 1.4 Další informace

Zatím žádné doplňující informace.
<br/><br/>

### 1.5 Kontakty

Email: kubin.krys@gmail.com
<br/><br/>

### 1.6 Odkazy na další dokumenty

Zatím se neodkazuje na další strany.
<br/><br/><br/>

## 2. Celkový popis

<br/><br/>

### 2.1 Produkt jako celek

Produkt pude vytvářen v Windows Presentation Foundation (WPF) a spouštěn jako .exe soubor.
<br/><br/>

### 2.2 Funkce

Aplikace budew mít funkce:
Interkace ve formě formuláře a vyzuální zobrazení pro zjištění informací s možností úpravy záznamu.
Záznamy budou zapisované v lokální databázi ve formě .csv a .json souboru ve stejné složce.

- _Záznam příjmů_ zaznamenávající množsví, datum přijmutí, odesilatele, stav transakce (přijaté, v processu, předpokládané) a volitelně kategorii a poznámku.
- _Záznam pladeb_ zaznamenávající množsví, datum odeslání, přímajícího, stav transakce (dokončená, v processu, plánovaná) a volitelně kategorii a poznámku.
- _Záznam zůstatku_ zaznemenávající množstí, volnost a kategorii.

<br/>

**Zabespečení**
Heslo a jméno uživatele a údeje v souboru csv budou uloženy ve formě hash.
<br/><br/>

### 2.3 Uživatelské skupiny

Aplikace bude vyžadovat rozdělení uživatelů na správce s plnýmy povoleními a pozorovately (tento požadavek nemusí být implementovaný).
<br/><br/>

### 2.4 Provozní prostředí

PC se systémem Windows. Není plánovaná expanze.
<br/><br/>

### 2.5 Uživatelské prostředí

Grafické Uživatelské Prostředí Windows Presetation Foundation ve formě souboru .exe.
<br/><br/>

### 2.6 Omezení návrhu a implementace

Z hledem k časovému omezení možnosti implementace se můžou specifikace dále měnit.
<br/><br/>

### 2.7 Předpoklady a závisloti

Malé využití CPU a operační paměti omezené šifrováním.
<br/><br/>

## 3. Požadavky na rozhraní
