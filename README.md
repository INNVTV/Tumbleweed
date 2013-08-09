Tumbleweed
==========

Simple & responsive customer waiting list signups for start-ups. Uses: ASP.NET MVC 5, Bootstrap 3 & Azure Table Storage.

Built using Boostrap RC 1, Azure SDK 2.1 for VS 2013 Preview & VS 2013 Preview 2, so an upgrade will be required. 

Emails signups are replicated in 2 tables. One sorted alphabetically: `waitinglistalphabetical` and the other by time: `waitinglisttime`

Signups page is the default route.

Reports can be viewed at the following routes: `/Report/List/Latest` & `/Report/List/Alpha`

* _ReportController Actions should be secured when put into production_

