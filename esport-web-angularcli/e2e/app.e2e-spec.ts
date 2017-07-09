import { EsportWebAngularcliPage } from './app.po';

describe('esport-web-angularcli App', () => {
  let page: EsportWebAngularcliPage;

  beforeEach(() => {
    page = new EsportWebAngularcliPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
