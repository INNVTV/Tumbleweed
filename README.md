Tumbleweed
==========

Simple & responsive waiting list for start-ups. Uses: ASP.NET MVC 5, Bootstrap 3 & Azure Table Storage.

Built using Boostrap 3 RC 1, Azure SDK 2.1 for VS 2013 Preview & VS 2013 Preview 2, so an upgrade will be required once final builds become available. 

##Details##

Emails signups are replicated in 2 tables. One sorted alphabetically: `waitinglistalphabetical` and the other by time: `waitinglisttime`


Reports can be viewed at the following routes: `/Report/List/Latest` & `/Report/List/Alpha`

Reports should be secured or removed when put into production.


##Configuration

Simply add your azure storage name/key in Web.config. That's all!
