# QTDrugPrescription  
  
**Inhaltsverzeichnis**  
1. [Einleitung](#einleitung)  
2. [Datenmodell und Datenbank](#datenmodell-und-datenbank)  
3. [Aufgaben](#aufgaben)  
   1. [Backend-System](#backend-System)  
      1. [Business-Logic](#business-logik)  
      2. [Unit-Tests](#unit-tests)  
      3. [RESTful-Services](#restful-services)  
      4. [AspMvc-Views](#aspmvc-views)  
  
## Einleitung  
  
Das Projekt ***QTDrugPrescription*** ist eine datenzentrierte Anwendung zur Verwaltung von Medikamentenverschreibungen.   
  
Zu entwickeln ist das Backend-System mit der Datenbank-Anbindung, eine Web-Anwendung zur Verwaltung der Stammdaten der Projekte. Zusätzlich soll ein mobiler Client zum Ansehen und Bearbeiten einer Aufgabe erstellt werden.  
  
## Datenmodell und Datenbank  
  
Das Datenmodell für ***QTDrugPrescription*** hat folgenden Aufbau:  
  
```txt  
  
+-------+--------+                    +-------+--------+   
|                |                    |                |   
|     Patient    + 1 -------------- N +  Prescription  +   
|                |                    |                |   
+-------+--------+                    +-------+--------+   
                                              N  
                                              |  
                                              |  
                                              |  
                                              1  
                                      +-------+--------+   
                                      |                |   
                                      +      Drug      +   
                                      |                |   
                                      +-------+--------+   
  
```  
  
### Definition von ***Patient***  
  
| Name | Type | MaxLength | Nullable |Unique|Db-Field|Access|  
|------|------|-----------|----------|------|--------|------|  
| Id | int |---|---|---| Yes | R |  
| RowVersion | byte[] |---| No |---| Yes | R |  
| Birthday | DateTime | --- | No | No | No | R |  
| SocialSecurityNumber | String | 10 | No | Yes | Yes | RW |  
| FirstName | String | 64 | No | No | Yes | RW |  
| LastName | String | 64 | No | No | Yes | RW |  
  
### Definition von ***Drug***  
  
| Name | Type | MaxLength | Nullable |Unique|Db-Field|Access|  
|------|------|-----------|----------|------|--------|------|  
| Id | int |---|---|---| Yes | R |  
| RowVersion | byte[] |---| No |---| Yes | R |  
| Number | String | 10 | No | Yes | Yes | RW |  
| Designation | String | 128 | No | No | Yes | RW |  
| Note | String | 2048 | No | No | Yes | RW |  
  
### Definition von ***Prescription***  
  
| Name | Type | MaxLength | Nullable |Unique|Db-Field|Access|  
|------|------|-----------|----------|------|--------|------|  
| Id | int |---|---|---| Yes | R |  
| RowVersion | byte[] |---| No |---| Yes | R |  
| PatientId | int | --- | No | No | No | RW |  
| DrugId | int | --- | No | No | No | RW |  
| Date* | DateTime | --- | No | No | Yes | RW |  
| Dosing | String | 1024 | No | No | Yes | RW |  
  
*...Das Datum wird im Format dd.MM.yyyy 00:00:00 erstellt - also ohne Zeitangabe.  

## Aufgaben  
  
### Backend-System  
  
Erstellen Sie das Backend-System mit der Vorlage ***QuickTemplate*** und definieren die folgenden ***Komponenten***:  
  
- Erstellen der ***Enumeration***  
  - *keine*  
- Erstellen der ***Entitäten***  
  - *Patient*  
  - *Drug*  
  - *Prescription*  
- Definition des ***Datenbank-Kontext***  
  - *DbSet&lt;Patient&gt;* definieren  
  - *DbSet&lt;Drug&gt;* definieren  
  - *DbSet&lt;Prescription&gt;* definieren  
  - partielle Methode ***GetDbSet<E>()*** implementieren  
- Erstellen der ***Kontroller*** im *Logic* Projekt  
  - ***PatientsController***  
  - ***DrugsController***  
  - ***PrecriptionsController***  
- Erstellen der ***Datenbank*** mit den Kommandos in der ***Package Manager Console***  
  - *add-migration InitDb*  
  - *update-database*  
- Implementierung der ***Business-Logic***  
  - Überprüfen der Geschäftslogik mit ***UnitTests***  
- Importieren von Daten (optional)  
  
#### Business-Logik  
  
Das System muss einige Geschäftsregeln umsetzen. Diese Regeln werden im Backend implementiert und müssen mit UnitTests überprüft werden.   
  
> **HINWEIS:** Unter **Geschäftsregeln** (Business-Rules) versteht man **elementare technische Sachverhalte** im Zusammenhang mit Computerprogrammen. Mit *WENN* *DANN* Scenarien werden die einzelnen Regeln beschrieben.  
  
Für das ***DrugPrescription*** sind folgende Regeln definiert:  
  
| Rule | Subject | Type | Operation | Description | Note |  
|------|---------|------|-----------|-------------|------|  
|**A1**| Patient |  |  |  |  |  
|  |  |*WENN*|  | ein Patient erstellt oder bearbeitet wird, |  |  
|  |  |*DANN*|  | muss die 'SocialSecurityNumber' gültig (siehe Prüfziffer) sein |  |  
|  |  |      | UND | die 'SocialSecurityNumber' muss eindeutig sein |  |  
|  |  |      | UND | der 'FirstName' muss aus mindestens 3 Zeichen bestehen |  |  
|  |  |      | UND | der 'LastName' muss aus mindestens 3 Zeichen bestehen. |  |  
|**B1**| Drug |  |  |  |  |  
|  |  |*WENN*|  | ein Medikament erstellt oder bearbeitet wird, |  |  
|  |  |*DANN*|  | muss die 'Number' gültig sein |  |  
|  |  |      | UND | die Bezeichnung (mind. 10 Zeichen) definiert sein. |  
|**C1**| Prescription |  |  |  |  |  
|  |  |*WENN*|  | eine Verschreibung erstellt oder bearbeitet wird, |  |  
|  |  |*DANN*|  | muss die Zuordnung 'Patient' gültig sein |  |  
|  |  |      | UND | die Zuordnung 'Drug' gültig sein |  
|  |  |      | UND | das Datum muss mit Format dd.MM.yyyy 00:00:00 gesetzt werden. |  
  
**Prüffziffer für die Sozial-Versicherungs-Nummer**  
  
Die Ziffernfolge wird von links nach rechts mit 3, 7, 9, 5, 8, 4, 2, 1, 6 gewichtet.  
Die Produkte werden summiert.  
Von der Summe wird der volle Rest zur nächst niedrigeren durch 11 teilbaren Zahl (modulo 11) bestimmt.  
Ist der Rest 10, wird die Nummer nicht vergeben.  
  
**Beispiel**: 328**p**171076  
  
|Nummer|Schritt 1-Gewichtung|Schritt 2-Produkt|  
|---|---|---|  
|3  |  3|  9|  
|2  |  7| 14|  
|8	|9	| 72|  
|**p**|   |   |	  
|1	|5	|  5|  
|7	|8	| 56|  
|1	|4	|  4|  
|0	|2	|  0|  
|7	|1	|  7|  
|6	|6	| 36|  
|Summe| |203|  
|Schritt 3: Summe mod 11| 203 ÷ 11 = 18 | Rest 5|  
|Endergebnis Prüfziffer | | 5 |  
  
**Sozial-Versicherungs-Nummer**: 328***5***171076  
  
Wenn die Sozial-Versicherungs-Nummer nicht stimmt (ungültige Prüfziffer), dann wird eine Ausnahme geworfen.  

**Prüfziffer für die Medikamenten-Nummer**  
  
Die Prüfziffer (zehnte Ziffer) der Nummer berechnet sich wie folgt:  
Man multipliziere die erste Ziffer mit eins, die zweite mit zwei, die dritte mit drei und so fort bis zur neunten Ziffer, die mit neun multipliziert wird.  
Man addiere die Produkte und teile die Summe ganzzahlig mit Rest durch 11. Der Divisionsrest ist die Prüfziffer.  
Falls der Rest 10 beträgt, ist die Prüfziffer ein "X".  

**1. Beispiel:** Medikamenten-Nummer 3-499-13599-[?]  
3·1 + 4·2 + 9·3 + 9·4 + 1·5 + 3·6 + 5·7 + 9·8 + 9·9 = 3 + 8 + 27 + 36 + 5 + 18 + 35 + 72 + 81 = 285  
285:11 = 25 Rest 10 ⇒ Prüfziffer: X  
**2. Beispiel:** Medikamenten-Nummer 3-446-19313-[?]  
3·1 + 4·2 + 4·3 + 6·4 + 1·5 + 9·6 + 3·7 + 1·8 + 3·9 = 3 + 8 + 12 + 24 + 5 + 54 + 21 + 8 + 27 = 162  
162:11 = 14 Rest 8 ⇒ Prüfziffer: 8  
**3. Beispiel:** Medikamenten-Nummer 0-7475-5100-[?]  
0·1 + 7·2 + 4·3 + 7·4 + 5·5 + 5·6 + 1·7 + 0·8 + 0·9 = 14 + 12 + 28 + 25 + 30 + 7 = 116  
116:11 = 10 Rest 6 ⇒ Prüfziffer: 6  
**4. Beispiel:** Medikamenten-Nummer 1-57231-422-[?]  
1·1 + 5·2 + 7·3 + 2·4 + 3·5 + 1·6 + 4·7 + 2·8 + 2·9 = 1 + 10 + 21 + 8 + 15 + 6 + 28 + 16 + 18 = 123  
23:11 = 11 Rest 2 ⇒ Prüfziffer: 2  
  
Wenn die Medikamenten-Nummer nicht stimmt (ungültige Prüfziffer), dann wird eine Ausnahme geworfen.  

#### Unit-Tests  
  
All diese Geschäftsregeln müssen mit **UnitTests** überprüft werden. Fügen Sie dazu zur Lösung (Solution) ein Projekt mit dem Namen ***'QTDrugPrescription.Logic.UnitTest'*** hinzu und implementieren Sie die Tests.  
   
#### RESTful-Services  
  
Erstellen Sie einen REST-Service Zugriff für die Entitäten ***'Project'*** und ***'Member'*** mit folgende Komponenten:  
  
- Ein ***Model*** für die Entität ***'Patient'***.  
- Einen ***Kontroller*** mit den folgenden Operationen  
  - Abfrage alle Patienten  
  - Abfrage eines Patienten mit der Id  
  - Abfrage aller Arztbesuche mit Verschreibungen (Datum einer Verschreibung gilt als Arztbesuch)  
  - Erstellen eines Patienten (SocialSecurityNumber, FirstName, LastName)  
  - Änderung eines Patienten (SocialSecurityNumber, FirstName, LastName)  
  - Löschen eines Patienten  
  
- Ein ***Model*** für die Entität ***'Drug'***.  
- Einen ***Kontroller*** mit den folgenden Operationen  
  - Abfrage alle Medikamente  
  - Abfrage eines Medikamentes mit der Id  
  - Erstellen eines Medikamentes (Number, Designation, Note)  
  - Änderung eines Medikamentes (Number, Designation, Note)  
  - Löschen eines Medikamentes  
  
- Ein ***Model*** für die Entität ***'Prescription'***.  
- Einen ***Kontroller*** mit den folgenden Operationen  
  - Abfrage alle Verschreibungen  
  - Abfrage einer Verschreibung mit der Id  
  - Erstellen eines Verschreibung (PatientId, DrugId, Dosing)  
  - Änderung eines Verschreibung (PatientId, DrugId, Dosing)  
  - Löschen eines Verschreibung  

Prüfen Sie mit dem Werkzeug Swagger die REST-Schnittstelle.  

### AspMvc-Views  
  
Erstellen Sie für die folgenden Entitäten Ansichten im AspMvc-Projekt:  
  
> Der Kontroller ***PatientsContoller*** ist bereits erstellt.  
  
- Patient   
  - ListView - Übersicht der Patienten  
  - Create - Erstellen eines Patienten  
  - Edit - Bearbeiten eines Patienten  
  - Delete - Löschen eines Patienten mit Rückfrage  
  
> Erstellen Sie den ***DrugsController*** nach dem gleichem Schema von ***PatientsController***.  
   
- Drug   
  - ListView - Übersicht der Medikamente  
  - Create - Erstellen eines Medikame  
  - Edit - Bearbeiten eines Medikaments  
  - Delete - Löschen eines Medikaments mit Rückfrage  
  
> Erstellen Sie den ***PrescriptionsController*** nach dem gleichem Schema von ***PatientsController***.  
   
- Prescription   
  - ListView - Übersicht über die Verschreibungen  
  - Create - Erstellen einer Verschreibung mit der Zuordnung Medikame und Patient (DropDownList)  
  - Edit - Bearbeiten einer Verschreibung mit der Zuordnung Medikame und Patient (DropDownList)  
  - Delete - Löschen einer Verschreibung mit Rückfrage  
  
> **HINWEIS:**  Ausnahmen und Fehler müssen dem Benutzer entsprechend angezeigt werden.  
  
**Viel Spaß beim Umsetzen der Aufgabe!**  